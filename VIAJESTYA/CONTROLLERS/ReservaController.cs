namespace VIAJESTYA.CONTROLLERS;
using VIAJESTYA.SERVICES;
using VIAJESTYA.models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly IReservaService _service;

    public ReservasController(IReservaService service)
    {
        _service = service;
    }

   
    [HttpGet]
    public async Task<ActionResult<List<Reserva>>> ObtenerTodas()
    {
        var reservas = await _service.ObtenerTodasLasReservasAsync();
        return Ok(reservas);
    }

 
    [HttpGet("{codigo}")]
    public async Task<ActionResult<Reserva>> ObtenerPorCodigo(int codigo)
    {
        try
        {
            var reserva = await _service.ObtenerReservaPorCodigoAsync(codigo);
            if (reserva == null)
                return NotFound("Reserva no encontrada");
            return Ok(reserva);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

 
    [HttpPost]
    public async Task<ActionResult<Reserva>> Crear([FromBody] Reserva reserva)
    {
        try
        {
            var reservaCreada = await _service.CrearReservaAsync(reserva);
            return CreatedAtAction(nameof(ObtenerPorCodigo), new { codigo = reservaCreada.Codigo }, reservaCreada);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

   
    [HttpPut("{codigo}")]
    public async Task<IActionResult> Actualizar(int codigo, [FromBody] Reserva reserva)
    {
        try
        {
            await _service.ActualizarReservaAsync(codigo, reserva);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
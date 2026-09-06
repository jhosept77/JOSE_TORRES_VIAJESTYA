namespace VIAJESTYA.CONTROLLERS;
using VIAJESTYA.SERVICES;
using VIAJESTYA.models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HotelesController : ControllerBase
{
    private readonly IHotelService _service;

    public HotelesController(IHotelService service)
    {
        _service = service;
    }

    
    [HttpGet]
    public async Task<ActionResult<List<Hotel>>> ObtenerTodos()
    {
        var hoteles = await _service.ObtenerTodosLosHotelesAsync();
        return Ok(hoteles);
    }

   
    [HttpGet("{nombre}")]
    public async Task<ActionResult<Hotel>> ObtenerPorNombre(string nombre)
    {
        try
        {
            var hotel = await _service.ObtenerHotelPorNombreAsync(nombre);
            if (hotel == null)
                return NotFound("Hotel no encontrado");
            return Ok(hotel);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    [HttpPost]
    public async Task<ActionResult<Hotel>> Crear([FromBody] Hotel hotel)
    {
        try
        {
            var hotelCreado = await _service.CrearHotelAsync(hotel);
            return CreatedAtAction(nameof(ObtenerPorNombre), new { nombre = hotelCreado.Nombre }, hotelCreado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    [HttpPut("{nombre}")]
    public async Task<IActionResult> Actualizar(string nombre, [FromBody] Hotel hotel)
    {
        try
        {
            await _service.ActualizarHotelAsync(hotel);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
namespace VIAJESTYA.CONTROLLERS;
using VIAJESTYA.SERVICES;
using VIAJESTYA.models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class VuelosController : ControllerBase
{
    private readonly IVueloService _service;

    public VuelosController(IVueloService service)
    {
        _service = service;
    }

    
    [HttpGet]
    public async Task<ActionResult<List<Vuelo>>> ObtenerTodos()
    {
        var vuelos = await _service.ObtenerTodosLosVuelosAsync();
        return Ok(vuelos);
    }

    
    [HttpGet("{numero}")]
    public async Task<ActionResult<Vuelo>> ObtenerPorNumero(int numero)
    {
        try
        {
            var vuelo = await _service.ObtenerVueloPorNumeroAsync(numero);
            if (vuelo == null)
                return NotFound("Vuelo no encontrado");
            return Ok(vuelo);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    [HttpPost]
    public async Task<ActionResult<Vuelo>> Crear([FromBody] Vuelo vuelo)
    {
        try
        {
            var vueloCreado = await _service.CrearVueloAsync(vuelo);
            return CreatedAtAction(nameof(ObtenerPorNumero), new { numero = vueloCreado.NumeroVuelo }, vueloCreado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    
    [HttpPut("{numero}")]
    public async Task<IActionResult> Actualizar(int numero, [FromBody] Vuelo vuelo)
    {
        try
        {
            await _service.ActualizarVueloAsync(numero, vuelo);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
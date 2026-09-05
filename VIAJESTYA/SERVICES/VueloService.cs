namespace VIAJESTYA.SERVICES;
using VIAJESTYA.models;
using VIAJESTYA.REPOSITORIES;

public class VueloService : IVueloService
{
    private readonly IVueloRepository _repository;

    public VueloService(IVueloRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Vuelo>> ObtenerTodosLosVuelosAsync()
    {
        return await _repository.ObtenerTodosLosVuelos();
    }

    public async Task<Vuelo> ObtenerVueloPorNumeroAsync(int numero)
    {
        if (numero <= 0)
            throw new ArgumentException("Número de vuelo debe ser mayor a 0");
        
        return await _repository.ObtenerVueloPorNumero(numero);
    }

    public async Task<Vuelo> CrearVueloAsync(Vuelo vuelo)
    {
     
        if (string.IsNullOrEmpty(vuelo.Origen))
            throw new ArgumentException("Origen requerido");
        
        if (string.IsNullOrEmpty(vuelo.Destino))
            throw new ArgumentException("Destino requerido");
        
        if (vuelo.FechayHoraSalida >= vuelo.FechayHoraLlegada)
            throw new ArgumentException("Fecha salida debe ser menor a fecha llegada");
        
        if (vuelo.Costo <= 0)
            throw new ArgumentException("Costo debe ser mayor a 0");

        
        return await _repository.CrearVuelo(vuelo);
    }

    public async Task ActualizarVueloAsync(int numero, Vuelo vuelo)
    {
        if (numero <= 0)
            throw new ArgumentException("Número de vuelo inválido");

        await _repository.ActualizarVuelo(numero, vuelo);
    }
}
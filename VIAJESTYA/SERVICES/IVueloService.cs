namespace VIAJESTYA.SERVICES;
using VIAJESTYA.models;

public interface IVueloService
{
    Task <List<Vuelo>> ObtenerTodosLosVuelosAsync();
    Task<Vuelo> ObtenerVueloPorNumeroAsync(int numero);
    Task<Vuelo> CrearVueloAsync(Vuelo vuelo);
    Task ActualizarVueloAsync(int numero, Vuelo vuelo);
}
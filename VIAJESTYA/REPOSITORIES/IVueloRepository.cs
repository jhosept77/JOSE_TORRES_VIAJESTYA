namespace VIAJESTYA.REPOSITORIES;
using VIAJESTYA.models;

public interface IVueloRepository
{
    Task<List<Vuelo>> ObtenerTodosLosVuelos();
    Task<Vuelo> ObtenerVueloPorNumero(int numero);
    Task<Vuelo> CrearVuelo(Vuelo vuelo);
    Task ActualizarVuelo(int numero, Vuelo vuelo);
}
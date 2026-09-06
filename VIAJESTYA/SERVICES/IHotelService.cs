namespace VIAJESTYA.SERVICES;
using VIAJESTYA.models;

public interface IHotelService
{
    Task<List<Hotel>> ObtenerTodosLosHotelesAsync();
    Task<Hotel> ObtenerHotelPorNombreAsync(string nombre);
    Task<Hotel> CrearHotelAsync(Hotel hotel);
    Task ActualizarHotelAsync(Hotel hotel);
}
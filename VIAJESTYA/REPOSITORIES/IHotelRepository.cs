using VIAJESTYA.models;
namespace VIAJESTYA.REPOSITORIES;

public interface IHotelRepository
{
    Task<List<Hotel>> ObtenerTodosLosHoteles();
    Task<Hotel> ObtenerHotelPorNombre(string nombre);
    Task<Hotel> CrearHotel(Hotel hotel);
    Task ActualizarHotel(Hotel hotel);
    
}
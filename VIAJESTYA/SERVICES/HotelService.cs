namespace VIAJESTYA.SERVICES;
using VIAJESTYA.models;
using VIAJESTYA.REPOSITORIES;

public class HotelService : IHotelService
{
    private readonly IHotelRepository _repository;

    public HotelService(IHotelRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Hotel>> ObtenerTodosLosHotelesAsync()
    {
        return await _repository.ObtenerTodosLosHoteles();
    }

    public async Task<Hotel> ObtenerHotelPorNombreAsync(string nombre)
    {
        if (string.IsNullOrEmpty(nombre))
            throw new ArgumentException("Nombre del hotel requerido");
        
        return await _repository.ObtenerHotelPorNombre(nombre);
    }

    public async Task<Hotel> CrearHotelAsync(Hotel hotel)
    {
        if (string.IsNullOrEmpty(hotel.Nombre))
            throw new ArgumentException("Nombre requerido");
        
        if (string.IsNullOrEmpty(hotel.Direccion))
            throw new ArgumentException("Dirección requerida");
        
        if (string.IsNullOrEmpty(hotel.Ciudad))
            throw new ArgumentException("Ciudad requerida");
        
        if (string.IsNullOrEmpty(hotel.Categoria))
            throw new ArgumentException("Categoría requerida");
        
        if (string.IsNullOrEmpty(hotel.Email))
            throw new ArgumentException("Email requerido");

        return await _repository.CrearHotel(hotel);
    }

    public async Task ActualizarHotelAsync(Hotel hotel)
    {
        if (string.IsNullOrEmpty(hotel.Nombre))
            throw new ArgumentException("Nombre requerido");

        await _repository.ActualizarHotel(hotel);
    }
}
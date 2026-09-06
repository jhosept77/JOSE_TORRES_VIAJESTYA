namespace VIAJESTYA.SERVICES;
using VIAJESTYA.models;
using VIAJESTYA.REPOSITORIES;

public class ReservaService : IReservaService
{
    private readonly IReservaRepository _repository;
    private readonly IVueloRepository _vueloRepository;
    private readonly IHotelRepository _hotelRepository;

    public ReservaService(IReservaRepository repository, IVueloRepository vueloRepository, IHotelRepository hotelRepository)
    {
        _repository = repository;
        _vueloRepository = vueloRepository;
        _hotelRepository = hotelRepository;
    }

    public async Task<List<Reserva>> ObtenerTodasLasReservasAsync()
    {
        return await _repository.ObtenerTodasLasReservas();
    }

    public async Task<Reserva> ObtenerReservaPorCodigoAsync(int codigo)
    {
        if (codigo <= 0)
            throw new ArgumentException("Código de reserva inválido");
        
        return await _repository.ObtenerReservaPorCodigo(codigo);
    }

    public async Task<Reserva> CrearReservaAsync(Reserva reserva)
    {
        
        if (reserva.NumeroPersonas <= 0)
            throw new ArgumentException("Número de personas debe ser mayor a 0");
        
        if (string.IsNullOrEmpty(reserva.NombreHotel))
            throw new ArgumentException("Nombre del hotel requerido");
        
        if (reserva.FechaInicio >= reserva.FechaFin)
            throw new ArgumentException("Fecha inicio debe ser menor a fecha fin");

        
        var vuelo = await _vueloRepository.ObtenerVueloPorNumero(reserva.NumeroVuelo);
        if (vuelo == null)
            throw new ArgumentException("Vuelo no encontrado");

        
        var hotel = await _hotelRepository.ObtenerHotelPorNombre(reserva.NombreHotel);
        if (hotel == null)
            throw new ArgumentException("Hotel no encontrado");

        return await _repository.CrearReserva(reserva);
    }

    public async Task ActualizarReservaAsync(int codigo, Reserva reserva)
    {
        if (codigo <= 0)
            throw new ArgumentException("Código de reserva inválido");

        if (reserva.NumeroPersonas <= 0)
            throw new ArgumentException("Número de personas debe ser mayor a 0");

        if (reserva.FechaInicio >= reserva.FechaFin)
            throw new ArgumentException("Fecha inicio debe ser menor a fecha fin");

        await _repository.ActualizarReserva(codigo, reserva);
    }
}
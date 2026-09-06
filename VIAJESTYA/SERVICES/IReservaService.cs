namespace VIAJESTYA.SERVICES;
using VIAJESTYA.models;

public interface IReservaService
{
    Task<List<Reserva>> ObtenerTodasLasReservasAsync();
    Task<Reserva> ObtenerReservaPorCodigoAsync(int codigo);
    Task<Reserva> CrearReservaAsync(Reserva reserva);
    Task ActualizarReservaAsync(int codigo, Reserva reserva);
}
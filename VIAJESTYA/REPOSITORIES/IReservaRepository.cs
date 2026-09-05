namespace VIAJESTYA.REPOSITORIES;
using VIAJESTYA.models;

public interface IReservaRepository
{
    Task<List<Reserva>> ObtenerTodasLasReservas();
    Task<Reserva> ObtenerReservaPorCodigo(int codigo);
    Task<Reserva> CrearReserva(Reserva reserva);
    Task ActualizarReserva(int codigo, Reserva reserva);
}
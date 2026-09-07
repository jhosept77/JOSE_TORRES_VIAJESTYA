namespace VIAJESTYA.PATRONES.FactoryMethod;

using VIAJESTYA.DTO;
using VIAJESTYA.models;

public class ReservaDtoFactory : IDtoFactory
{
    public object Crear(TipoProyecto tipo, object datos)
    {
        if (datos is not CreateReservaDTO dto)
            throw new ArgumentException("Se esperaba CreateReservaDTO");

        return tipo switch
        {
            TipoProyecto.ReservaEstandar => CrearReservaEstandar(dto),
            TipoProyecto.ReservaGrupal => CrearReservaGrupal(dto),
            _ => throw new ArgumentException("Tipo no soportado para reservas")
        };
    }

    private Reserva CrearReservaEstandar(CreateReservaDTO dto)
    {
        return Reserva.DesdeDTO(dto, Random.Shared.Next(10000, 99999));
    }

    private Reserva CrearReservaGrupal(CreateReservaDTO dto)
    {
        if (dto.NumeroPersonas < 5)
            throw new ArgumentException("Una reserva grupal requiere al menos 5 personas");

        var reserva = Reserva.DesdeDTO(dto, Random.Shared.Next(10000, 99999));
        reserva.Estado = "Grupal-Pendiente";
        return reserva;
    }
}
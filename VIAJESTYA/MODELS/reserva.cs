namespace VIAJESTYA.models;
using VIAJESTYA.DTO;

public class Reserva
{
    public int Codigo { get; set; }
    public DateOnly FechadeReserva { get; set; }
    public DateOnly FechaInicio { get; set; }
    public DateOnly FechaFin { get; set; }
    public int NumeroPersonas { get; set; }
    public int NumeroVuelo  { get; set; }
    public string NombreHotel { get; set; }
    public string Estado { get; set; }
    
    public Reserva()
    {
    }

    public Reserva(int codigo, int numerovuelo, int numeropersonas, string nombrehotel, string estado,
        DateOnly fechadereserva, DateOnly fechafin, DateOnly fechainicio)
    {
        this.Codigo = codigo;
        this.NumeroVuelo = numerovuelo;
        this.NombreHotel = nombrehotel;
        this.Estado = estado;
        this.FechadeReserva = fechadereserva;
        this.FechaInicio = fechainicio;
        this.FechaFin = fechafin;
        this.NumeroPersonas = numeropersonas;
    }

    public static Reserva DesdeDTO(CreateReservaDTO dto, int nuevocodigo)
    {
        return new Reserva(
            codigo: nuevocodigo,
            numerovuelo: dto.NumeroVuelo,
            numeropersonas: dto.NumeroPersonas,
            nombrehotel: dto.NombreHotel,
            estado: "Pendiente",
            fechadereserva: DateOnly.FromDateTime(DateTime.Today),
            fechafin: dto.FechaFin,
            fechainicio: dto.FechaInicio
        );
    }
}
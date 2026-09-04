namespace VIAJESTYA.models;
using VIAJESTYA.DTO;

public class Vuelo
{
    public string Origen { get; set; }
    public string Destino { get; set; }
    public DateTime FechayHoraSalida { get; set; }
    public DateTime FechayHoraLlegada { get; set; }
    public decimal Costo { get; set; }
    public int NumeroVuelo { get; set; }
    public string Estado { get; set; }


    public Vuelo()
    {
    }
    
    
    
    public Vuelo(string origen, string destino, DateTime fechayhorallegada,int numerovuelo, DateTime fechayhorasalida, decimal costo,
         string estado)
    {
        this.Origen = origen;
        this.Destino = destino;
        this.FechayHoraSalida = fechayhorasalida;
        this.NumeroVuelo = numerovuelo;
        this.FechayHoraLlegada = fechayhorallegada;
        this.Costo = costo;
        this.Estado = estado;
    }


    public static Vuelo VueloDesdeOTD(CreateVueloDOT odt, int newnovuelo, decimal newcostos)
    {
        return new Vuelo(
            origen: odt.Origen,
            destino: odt.Destino,
            fechayhorallegada: odt.FechaRegreso,
            fechayhorasalida: odt.FechaSalida,
            numerovuelo: newnovuelo,
            costo: newcostos,
            estado: "Pendiente"
        );
    }
}
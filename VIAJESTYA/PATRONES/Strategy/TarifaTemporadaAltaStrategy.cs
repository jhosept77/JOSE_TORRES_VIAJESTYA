namespace VIAJESTYA.PATRONES.Strategy;

using VIAJESTYA.models;

public class TarifaTemporadaAltaStrategy : ICalculoTarifaStrategy
{
    public string Nombre => "Tarifa Temporada Alta";

    public decimal Calcular(Vuelo vuelo, int numeroPersonas)
    {
        return vuelo.Costo * numeroPersonas * 1.25m; // +25%
    }
}
namespace VIAJESTYA.PATRONES.Strategy;

using VIAJESTYA.models;

public class TarifaEstandarStrategy : ICalculoTarifaStrategy
{
    public string Nombre => "Tarifa Estándar";

    public decimal Calcular(Vuelo vuelo, int numeroPersonas)
    {
        return vuelo.Costo * numeroPersonas;
    }
}
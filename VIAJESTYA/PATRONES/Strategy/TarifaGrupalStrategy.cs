namespace VIAJESTYA.PATRONES.Strategy;

using VIAJESTYA.models;

public class TarifaGrupalStrategy : ICalculoTarifaStrategy
{
    public string Nombre => "Tarifa Grupal";

    public decimal Calcular(Vuelo vuelo, int numeroPersonas)
    {
        var total = vuelo.Costo * numeroPersonas;

        if (numeroPersonas >= 10)
            total *= 0.80m; // 20% descuento
        else if (numeroPersonas >= 5)
            total *= 0.90m; // 10% descuento

        return total;
    }
}
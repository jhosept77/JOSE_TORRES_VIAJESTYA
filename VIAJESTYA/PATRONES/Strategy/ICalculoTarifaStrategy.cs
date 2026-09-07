namespace VIAJESTYA.PATRONES.Strategy;

using VIAJESTYA.models;

public interface ICalculoTarifaStrategy
{
    decimal Calcular(Vuelo vuelo, int numeroPersonas);
    string Nombre { get; }
}
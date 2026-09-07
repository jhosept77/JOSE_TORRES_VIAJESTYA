namespace VIAJESTYA.PATRONES.Strategy;

using VIAJESTYA.models;

public class CalculadoraTarifaContext
{
    private ICalculoTarifaStrategy _strategy;

    public CalculadoraTarifaContext(ICalculoTarifaStrategy strategy)
    {
        _strategy = strategy;
    }

    
    public void SetStrategy(ICalculoTarifaStrategy strategy)
    {
        _strategy = strategy;
    }

    public string StrategyActual => _strategy.Nombre;

    public decimal CalcularTarifa(Vuelo vuelo, int numeroPersonas)
    {
        return _strategy.Calcular(vuelo, numeroPersonas);
    }
}
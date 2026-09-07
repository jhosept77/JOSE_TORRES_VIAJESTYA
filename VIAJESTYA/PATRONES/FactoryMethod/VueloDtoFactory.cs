namespace VIAJESTYA.PATRONES.FactoryMethod;

using VIAJESTYA.DTO;
using VIAJESTYA.models;

public class VueloDtoFactory : IDtoFactory
{
    public object Crear(TipoProyecto tipo, object datos)
    {
        if (datos is not CreateVueloDOT dto)
            throw new ArgumentException("Se esperaba CreateVueloDOT");

        return tipo switch
        {
            TipoProyecto.VueloNacional => CrearVueloNacional(dto),
            TipoProyecto.VueloInternacional => CrearVueloInternacional(dto),
            _ => throw new ArgumentException("Tipo no soportado para vuelos")
        };
    }

    private Vuelo CrearVueloNacional(CreateVueloDOT dto)
    {
        // Reglas de vuelo nacional
        return Vuelo.VueloDesdeOTD(dto, Random.Shared.Next(1000, 9999), 150000m);
    }

    private Vuelo CrearVueloInternacional(CreateVueloDOT dto)
    {
        // Reglas de vuelo internacional
        var vuelo = Vuelo.VueloDesdeOTD(dto, Random.Shared.Next(1000, 9999), 850000m);
        vuelo.Estado = "RequierePasaporte";
        return vuelo;
    }
}
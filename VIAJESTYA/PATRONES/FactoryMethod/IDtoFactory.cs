namespace VIAJESTYA.PATRONES.FactoryMethod;

using VIAJESTYA.DTO;
using VIAJESTYA.models;

public interface IDtoFactory
{
    object Crear(TipoProyecto tipo, object datos);
}

public enum TipoProyecto
{
    VueloNacional,
    VueloInternacional,
    ReservaEstandar,
    ReservaGrupal
}
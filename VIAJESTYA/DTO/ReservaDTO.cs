namespace VIAJESTYA.DTO;

public record CreateReservaDTO(
    int NumeroVuelo,
    string NombreHotel,
    DateOnly FechaInicio,
    DateOnly FechaFin,
    int NumeroPersonas
    );
    
    
public record DetalleReservaDTO(
    int Codigo,
    int NumeroVuelo,
    string NombreHotel,
    string Estado,
    DateOnly FechaInicio,
    DateOnly FechaFin,
    int NumeroPersonas,
    int TotalDias
    );
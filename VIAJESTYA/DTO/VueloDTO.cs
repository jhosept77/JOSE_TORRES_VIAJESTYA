namespace VIAJESTYA.DTO;

public record CreateVueloDOT(
    string Origen,
    string Destino,
    DateTime FechaSalida,
    DateTime FechaRegreso
    );
    
    
public record VueloResponseDTO(
    int NoVuelo,
    string Origen,
    string Destino,
    DateTime FechaSalida,
    DateTime FechaRegreso,
    decimal Costo,
    string Estado
);


public record VueloUpdateDTO(
    string Destino,
    DateTime FechaSalida,
    DateTime FechaRegreso
);
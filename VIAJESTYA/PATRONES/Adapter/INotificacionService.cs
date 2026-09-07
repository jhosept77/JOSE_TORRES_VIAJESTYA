namespace VIAJESTYA.PATRONES.Adapter;

public interface INotificacionService
{
    Task EnviarConfirmacionReservaAsync(string destinatario, string mensaje);
    Task EnviarAlertaDisponibilidadAsync(string destinatario, string mensaje);
}
namespace VIAJESTYA.PATRONES.Adapter;

public class EmailNotificacionAdapter : INotificacionService
{
    private readonly ProveedorEmailExterno _proveedor;
    private readonly string _remitente;

    public EmailNotificacionAdapter(ProveedorEmailExterno proveedor, string remitente = "noreply@viajesya.com")
    {
        _proveedor = proveedor;
        _remitente = remitente;
    }

    public async Task EnviarConfirmacionReservaAsync(string destinatario, string mensaje)
    {
        await _proveedor.SendRawEmail(
            _remitente,
            destinatario,
            "Confirmación de Reserva - ViajesYA",
            $"<h2>Confirmación</h2><p>{mensaje}</p>"
        );
    }

    public async Task EnviarAlertaDisponibilidadAsync(string destinatario, string mensaje)
    {
        await _proveedor.SendRawEmail(
            _remitente,
            destinatario,
            "Alerta de Disponibilidad - ViajesYA",
            $"<h2>Disponibilidad</h2><p>{mensaje}</p>"
        );
    }
}
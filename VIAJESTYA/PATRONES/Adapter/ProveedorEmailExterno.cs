namespace VIAJESTYA.PATRONES.Adapter;


public class ProveedorEmailExterno
{
    public Task<bool> SendRawEmail(string from, string to, string subject, string bodyHtml)
    {
        Console.WriteLine($"[Proveedor Externo] Enviando correo...");
        Console.WriteLine($"  De: {from}");
        Console.WriteLine($"  Para: {to}");
        Console.WriteLine($"  Asunto: {subject}");
        Console.WriteLine($"  Mensaje: {bodyHtml}");
        return Task.FromResult(true);
    }
}
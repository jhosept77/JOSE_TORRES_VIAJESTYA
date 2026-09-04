namespace VIAJESTYA.models;

public class Hotel
{
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Ciudad { get; set; }
    public string Categoria { get; set; }
    public string Email { get; set; }


    public Hotel()
    {
    }

    public Hotel(string nombre, string direccion, string telefono, string ciudad, string categoria, string email)
    {
        this.Nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.Ciudad = ciudad;
        this.Categoria = categoria;
        this.Email = email;
        
    }
}
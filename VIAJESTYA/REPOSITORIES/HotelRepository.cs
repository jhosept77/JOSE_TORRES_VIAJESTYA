namespace VIAJESTYA.REPOSITORIES;
using VIAJESTYA.models;
using Npgsql;

public class HotelRepository : IHotelRepository
{
    private readonly string _connectionString;

    public HotelRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Hotel>> ObtenerTodosLosHoteles()
    {
        var hoteles = new List<Hotel>();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM hoteles";
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        hoteles.Add(new Hotel
                        {
                            Nombre = (string)reader["nombre"],
                            Direccion = (string)reader["direccion"],
                            Telefono = (string)reader["telefono"],
                            Ciudad = (string)reader["ciudad"],
                            Categoria = (string)reader["categoria"],
                            Email = (string)reader["email"]
                        });
                    }
                }
            }
        }
        return hoteles;
    }

    public async Task<Hotel> ObtenerHotelPorNombre(string nombre)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM hoteles WHERE nombre = @nombre";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Hotel
                        {
                            Nombre = (string)reader["nombre"],
                            Direccion = (string)reader["direccion"],
                            Telefono = (string)reader["telefono"],
                            Ciudad = (string)reader["ciudad"],
                            Categoria = (string)reader["categoria"],
                            Email = (string)reader["email"]
                        };
                    }
                }
            }
        }
        return null;
    }

    public async Task<Hotel> CrearHotel(Hotel hotel)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "INSERT INTO hoteles (nombre, direccion, telefono, ciudad, categoria, email) VALUES (@nombre, @direccion, @telefono, @ciudad, @categoria, @email)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombre", hotel.Nombre);
                command.Parameters.AddWithValue("@direccion", hotel.Direccion);
                command.Parameters.AddWithValue("@telefono", hotel.Telefono);
                command.Parameters.AddWithValue("@ciudad", hotel.Ciudad);
                command.Parameters.AddWithValue("@categoria", hotel.Categoria);
                command.Parameters.AddWithValue("@email", hotel.Email);

                await command.ExecuteNonQueryAsync();
            }
        }
        return hotel;
    }

    public async Task ActualizarHotel(Hotel hotel)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "UPDATE hoteles SET direccion=@direccion, telefono=@telefono, ciudad=@ciudad, categoria=@categoria, email=@email WHERE nombre=@nombre";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombre", hotel.Nombre);
                command.Parameters.AddWithValue("@direccion", hotel.Direccion);
                command.Parameters.AddWithValue("@telefono", hotel.Telefono);
                command.Parameters.AddWithValue("@ciudad", hotel.Ciudad);
                command.Parameters.AddWithValue("@categoria", hotel.Categoria);
                command.Parameters.AddWithValue("@email", hotel.Email);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
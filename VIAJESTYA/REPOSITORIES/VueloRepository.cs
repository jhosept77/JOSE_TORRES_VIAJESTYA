namespace VIAJESTYA.REPOSITORIES;
using VIAJESTYA.models;
using Npgsql;

public class VueloRepository : IVueloRepository
{
    private readonly string _connectionString;

    public VueloRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Vuelo>> ObtenerTodosLosVuelos()
    {
        var vuelos = new List<Vuelo>();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM vuelos";
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        vuelos.Add(new Vuelo
                        {
                            NumeroVuelo = (int)reader["numero_vuelo"],
                            Origen = (string)reader["origen"],
                            Destino = (string)reader["destino"],
                            FechayHoraSalida = (DateTime)reader["fecha_salida"],
                            FechayHoraLlegada = (DateTime)reader["fecha_llegada"],
                            Costo = (decimal)reader["costo"],
                            Estado = (string)reader["estado"]
                        });
                    }
                }
            }
        }
        return vuelos;
    }

    public async Task<Vuelo> ObtenerVueloPorNumero(int numero)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM vuelos WHERE numero_vuelo = @numero";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numero", numero);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Vuelo
                        {
                            NumeroVuelo = (int)reader["numero_vuelo"],
                            Origen = (string)reader["origen"],
                            Destino = (string)reader["destino"],
                            FechayHoraSalida = (DateTime)reader["fecha_salida"],
                            FechayHoraLlegada = (DateTime)reader["fecha_llegada"],
                            Costo = (decimal)reader["costo"],
                            Estado = (string)reader["estado"]
                        };
                    }
                }
            }
        }
        return null;
    }

    public async Task<Vuelo> CrearVuelo(Vuelo vuelo)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "INSERT INTO vuelos (origen, destino, fecha_salida, fecha_llegada, costo, estado) VALUES (@origen, @destino, @fechaSalida, @fechaLlegada, @costo, @estado) RETURNING numero_vuelo";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@origen", vuelo.Origen);
                command.Parameters.AddWithValue("@destino", vuelo.Destino);
                command.Parameters.AddWithValue("@fechaSalida", vuelo.FechayHoraSalida);
                command.Parameters.AddWithValue("@fechaLlegada", vuelo.FechayHoraLlegada);
                command.Parameters.AddWithValue("@costo", vuelo.Costo);
                command.Parameters.AddWithValue("@estado", vuelo.Estado);

                vuelo.NumeroVuelo = (int)await command.ExecuteScalarAsync();
            }
        }
        return vuelo;
    }

    public async Task ActualizarVuelo(int numero, Vuelo vuelo)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "UPDATE vuelos SET origen=@origen, destino=@destino, fecha_salida=@fechaSalida, fecha_llegada=@fechaLlegada, costo=@costo, estado=@estado WHERE numero_vuelo=@numero";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@numero", numero);
                command.Parameters.AddWithValue("@origen", vuelo.Origen);
                command.Parameters.AddWithValue("@destino", vuelo.Destino);
                command.Parameters.AddWithValue("@fechaSalida", vuelo.FechayHoraSalida);
                command.Parameters.AddWithValue("@fechaLlegada", vuelo.FechayHoraLlegada);
                command.Parameters.AddWithValue("@costo", vuelo.Costo);
                command.Parameters.AddWithValue("@estado", vuelo.Estado);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
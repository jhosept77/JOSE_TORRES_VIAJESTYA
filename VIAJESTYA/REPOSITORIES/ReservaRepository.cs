namespace VIAJESTYA.REPOSITORIES;
using VIAJESTYA.models;
using Npgsql;

public class ReservaRepository : IReservaRepository
{
    private readonly string _connectionString;

    public ReservaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<Reserva>> ObtenerTodasLasReservas()
    {
        var reservas = new List<Reserva>();
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM reservas";
            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        reservas.Add(new Reserva
                        {
                            Codigo = (int)reader["codigo"],
                            FechadeReserva = (DateOnly)reader["fechade_reserva"],
                            FechaInicio = (DateOnly)reader["fecha_inicio"],
                            FechaFin = (DateOnly)reader["fecha_fin"],
                            NumeroPersonas = (int)reader["numero_personas"],
                            NumeroVuelo = (int)reader["numero_vuelo"],
                            NombreHotel = (string)reader["nombre_hotel"],
                            Estado = (string)reader["estado"]
                        });
                    }
                }
            }
        }
        return reservas;
    }

    public async Task<Reserva> ObtenerReservaPorCodigo(int codigo)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM reservas WHERE codigo = @codigo";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@codigo", codigo);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Reserva
                        {
                            Codigo = (int)reader["codigo"],
                            FechadeReserva = (DateOnly)reader["fechade_reserva"],
                            FechaInicio = (DateOnly)reader["fecha_inicio"],
                            FechaFin = (DateOnly)reader["fecha_fin"],
                            NumeroPersonas = (int)reader["numero_personas"],
                            NumeroVuelo = (int)reader["numero_vuelo"],
                            NombreHotel = (string)reader["nombre_hotel"],
                            Estado = (string)reader["estado"]
                        };
                    }
                }
            }
        }
        return null;
    }

    public async Task<Reserva> CrearReserva(Reserva reserva)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "INSERT INTO reservas (fechade_reserva, fecha_inicio, fecha_fin, numero_personas, numero_vuelo, nombre_hotel, estado) VALUES (@fechadeReserva, @fechaInicio, @fechaFin, @numeroPersonas, @numeroVuelo, @nombreHotel, @estado) RETURNING codigo";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@fechadeReserva", reserva.FechadeReserva);
                command.Parameters.AddWithValue("@fechaInicio", reserva.FechaInicio);
                command.Parameters.AddWithValue("@fechaFin", reserva.FechaFin);
                command.Parameters.AddWithValue("@numeroPersonas", reserva.NumeroPersonas);
                command.Parameters.AddWithValue("@numeroVuelo", reserva.NumeroVuelo);
                command.Parameters.AddWithValue("@nombreHotel", reserva.NombreHotel);
                command.Parameters.AddWithValue("@estado", reserva.Estado);

                reserva.Codigo = (int)await command.ExecuteScalarAsync();
            }
        }
        return reserva;
    }

    public async Task ActualizarReserva(int codigo, Reserva reserva)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "UPDATE reservas SET fechade_reserva=@fechadeReserva, fecha_inicio=@fechaInicio, fecha_fin=@fechaFin, numero_personas=@numeroPersonas, numero_vuelo=@numeroVuelo, nombre_hotel=@nombreHotel, estado=@estado WHERE codigo=@codigo";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@codigo", codigo);
                command.Parameters.AddWithValue("@fechadeReserva", reserva.FechadeReserva);
                command.Parameters.AddWithValue("@fechaInicio", reserva.FechaInicio);
                command.Parameters.AddWithValue("@fechaFin", reserva.FechaFin);
                command.Parameters.AddWithValue("@numeroPersonas", reserva.NumeroPersonas);
                command.Parameters.AddWithValue("@numeroVuelo", reserva.NumeroVuelo);
                command.Parameters.AddWithValue("@nombreHotel", reserva.NombreHotel);
                command.Parameters.AddWithValue("@estado", reserva.Estado);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
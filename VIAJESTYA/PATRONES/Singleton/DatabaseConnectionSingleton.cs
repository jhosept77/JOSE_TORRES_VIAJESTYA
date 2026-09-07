namespace VIAJESTYA.PATRONES.Singleton;

using Npgsql;

public sealed class DatabaseConnectionSingleton
{
    
    private static readonly Lazy<DatabaseConnectionSingleton> _instance =
        new Lazy<DatabaseConnectionSingleton>(() => new DatabaseConnectionSingleton());

    private readonly string _connectionString;
    private NpgsqlConnection? _connection;

   
    private DatabaseConnectionSingleton()
    {
        _connectionString = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=Gorilas117";
    }


    public static DatabaseConnectionSingleton Instance => _instance.Value;

    public async Task<NpgsqlConnection> GetConnectionAsync()
    {
        if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
        {
            _connection?.Dispose();
            _connection = new NpgsqlConnection(_connectionString);
            await _connection.OpenAsync();
        }
        return _connection;
    }

    public string GetInstanceId() => GetHashCode().ToString();
}
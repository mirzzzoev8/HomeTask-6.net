using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string _connectionstring = 
    "Host=localhost;Port=5432;Database=Shop;User Id=postgres;Password=2008;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionstring);
    }
}

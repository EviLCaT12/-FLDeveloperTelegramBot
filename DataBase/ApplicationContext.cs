using Npgsql;

namespace DataBase;

public class ApplicationContext
{
    private readonly string connectionString;
    private readonly NpgsqlDataSource dataSource;
    private readonly NpgsqlConnection connection;

    public ApplicationContext(string connectionString)
    {
        this.connectionString = connectionString;
        dataSource = NpgsqlDataSource.Create(connectionString);
        connection = dataSource.OpenConnection();
        Console.WriteLine("Im working!!!");
    }
}
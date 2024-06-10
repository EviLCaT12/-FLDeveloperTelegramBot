using Npgsql;

namespace DataBase;

public class ApplicationContext
{

    private readonly NpgsqlDataSource dataSource;
    public NpgsqlConnection connection;

    public ApplicationContext(string connectionString)
    {
        dataSource = NpgsqlDataSource.Create(connectionString);
        connection = dataSource.OpenConnection();
        Console.WriteLine("DataBase connect was good");
    }
}
using Npgsql;
using domain.Logic.Inrefaces;
using domain.Models;
using DataBase.Converters;

namespace DataBase.Repository;
public class FlatRepository : IFlatRepository
{
    private ApplicationContext _context;
    public FlatRepository()
    {
        _context = new ApplicationContext("Host=localhost;Username=postgres;Password=qwerty123;Database=tg_bot");
    }

    public List<Flat> GetFlatsByPriceAndArea(int lowPrice, int highPrice, double lowArea, double highArea)
    {
        var stringCommand = "SELECT * FROM flats WHERE price BETWEEN @lowPrice AND @highPrice AND area BETWEEN @lowArea AND @highArea";
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        command.Parameters.AddWithValue("lowPrice", lowPrice);
        command.Parameters.AddWithValue("highPrice", highPrice);
        command.Parameters.AddWithValue("lowArea", lowArea);
        command.Parameters.AddWithValue("highArea", highArea);
        using var reader = command.ExecuteReader();

        List<Flat> flats = new List<Flat>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var newFlat = FlatConverter.ToDomain(reader);
                flats.Add(newFlat);
            }
            return flats;
        }
        return flats;
    }

    public List<Flat> GetFlatsByWindowWorldeSide(int worldSide)
    {
        var stringCommand = "SELECT * FROM flats WHERE windows_world_side = @worldSIde";
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        command.Parameters.AddWithValue("worldSide", worldSide);
        using var reader =  command.ExecuteReader();
        List<Flat> flats = new List<Flat>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var newFlat = FlatConverter.ToDomain(reader);
                flats.Add(newFlat);
            };
            return flats;
        }    
        return flats;
    }

    public List<Flat> GetFlatsForYoungFamily(List<InfrastructureObject> infObjects)
    {
        string objectList = "";
        foreach (var infObj in infObjects)
        {
            objectList += "'" + infObj.Name + "',";
        }
        objectList = objectList.Remove(objectList.Length - 1);

        string stringCommand = "SELECT DISTINCT flats.* " + 
                                "FROM ( " +  
                                    "SELECT rcio.resedential_complex_id, rcio.infrastructure_object_id " + 
                                    "FROM resedential_complexes_infrastructure_objects as rcio " +
                                    "INNER JOIN infrastructure_objects as io " +
                                    "ON rcio.infrastructure_object_id = io.id " +
                                    "WHERE io.name IN (" + objectList + ")) as result " +
                                "INNER JOIN flats " +
                                "ON flats.resedential_complex_id = result.resedential_complex_id ORDER BY flats.id";
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        using var reader = command.ExecuteReader();
        List<Flat> flats = new List<Flat>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var newFlat = FlatConverter.ToDomain(reader);
                flats.Add(newFlat);
            };
            return flats;
        }
        return flats;
    }

    public List<InfrastructureObject> GetAllUniqueInfObjects()
    {
        var stringCommand = "SELECT * FROM infrastructure_objects";
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        using var reader = command.ExecuteReader();
        List<InfrastructureObject> infObjects = new List<InfrastructureObject>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var infObj = new InfrastructureObject()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                infObjects.Add(infObj);
            }
            return infObjects;
        }
        return infObjects;
    }
}
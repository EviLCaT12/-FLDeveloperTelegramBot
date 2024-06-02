using Npgsql;
using domain.Logic.Inrefaces;
using domain.Models;

namespace DataBase.Repository;
public class FlatRepository : IFlatRepository
{
    private ApplicationContext _context;
    public FlatRepository()
    {
        _context = new ApplicationContext("Host=localhost;Username=postgres;Password=qwerty123;Database=feip_task");
    }

    public async Task<IEnumerable<Flat>> GetFlatsByPriceAndArea(int lowPrice, int highPrice, double lowArea, double highArea)
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
            while (await reader.ReadAsync())
            {
                var newFlat = new Flat() {
                    Id = reader.GetInt32(0),
                    ResidentialComplexId = reader.GetInt32(1),
                    Price = reader.GetInt32(2),
                    Area = reader.GetDouble(3),
                    RoomQuantity = reader.GetInt32(4),
                    FloorNumber = reader.GetInt32(5),
                    WorldSide = (WorldSide)reader.GetInt32(6),
                    Status = (BuildingStatus)reader.GetInt32(7),
                    IsMortgageAvailable = reader.GetBoolean(8),
                    IsSold = reader.GetBoolean(9)
                };
                flats.Add(newFlat);
            }
            return flats;
        }
        return flats;
    }

    public IEnumerable<Flat> GetFlatsByWindowWorldeSide(WorldSide worldSide)
    {
        var stringCommand = string.Format("SELECT id FROM flats WHERE world_side = {0} ", (int)worldSide);
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        using var reader =  command.ExecuteReader();
        List<Flat> flats = new List<Flat>();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var newFlat = new Flat() {
                    Id = reader.GetInt32(0),
                    ResidentialComplexId = reader.GetInt32(1),
                    Price = reader.GetInt32(2),
                    Area = reader.GetDouble(3),
                    RoomQuantity = reader.GetInt32(4),
                    FloorNumber = reader.GetInt32(5),
                    WorldSide = (WorldSide)reader.GetInt32(6),
                    Status = (BuildingStatus)reader.GetInt32(7),
                    IsMortgageAvailable = reader.GetBoolean(8),
                    IsSold = reader.GetBoolean(9)
                };
                flats.Add(newFlat);
            }
            return flats;
        }
        return flats;
    }

    public IEnumerable<Flat> GetFlatsForYoungFamile()
    {
        throw new NotImplementedException();
    }
}
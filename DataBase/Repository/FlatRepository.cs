using Npgsql;
using domain.Logic.Inrefaces;
using domain.Models;

namespace DataBase.Repository;
public class FlatRepository : IFlatRepository
{
    public ApplicationContext _context;
    public FlatRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Flat> GetFlatsByArea(double area)
    {
        var stringCommand = string.Format("SELECT id FROM flats WHERE area <= {0}", area);
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        using var reader =  command.ExecuteReader();
        if (reader.HasRows)
        {
            List<int> flatsId = new List<int>();
            while ( reader.Read())
            {
                int id = (int)reader["id"];
                flatsId.Add(id);
            }
            return (IEnumerable<Flat>)flatsId;
        }
        else 
        { 
            return null;
        }
    }

    public IEnumerable<Flat> GetFlatsByPrice(int price)
    {
        var stringCommand = string.Format("SELECT id FROM flats WHERE area <= {0}", price);
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        using var reader =  command.ExecuteReader();
        if (reader.HasRows)
        {
            List<int> flatsId = new List<int>();
            while ( reader.Read())
            {
                int id = (int)reader["id"];
                flatsId.Add(id);
            }
            return (IEnumerable<Flat>)flatsId;
        }
        else 
        { 
            return null;
        }
    }

    public IEnumerable<Flat> GetFlatsByWorldeSide(WorldSide worldSide)
    {
        var stringCommand = string.Format("SELECT id FROM flats WHERE world_side = {0} ", (int)worldSide);
        using var command = new NpgsqlCommand(stringCommand, _context.connection);
        using var reader =  command.ExecuteReader();
        if (reader.HasRows)
        {
            List<int> flatsId = new List<int>();
            while ( reader.Read())
            {
                int id = (int)reader["id"];
                flatsId.Add(id);
            }
            return (IEnumerable<Flat>)flatsId;
        }
        else 
        { 
            return null;
        }
    }

    public IEnumerable<Flat> GetFlatsForYoungFamile()
    {
        throw new NotImplementedException();
    }
}
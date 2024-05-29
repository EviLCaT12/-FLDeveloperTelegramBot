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
        throw new NotImplementedException();
    }

    public IEnumerable<Flat> GetFlatsByPrice(int price)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Flat> GetFlatsByWorldeSide(WorldSide worldSide)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Flat> GetFlatsForYoungFamile()
    {
        throw new NotImplementedException();
    }
}
using Logic.Models;

namespace Logic.Inrefaces
{
    public interface IFlatRepository : IRepository<Flat>
    {
        IEnumerable<Flat> GetFlatByPrice (int price);
        IEnumerable<Flat> GetFlatByArea (double area);
        IEnumerable<Flat> GetFlatForYoungFamile();
        IEnumerable<Flat> GetFlatByWorldeSide(WorldSide worldSide);
    }
}
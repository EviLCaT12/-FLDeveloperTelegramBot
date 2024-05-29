using domain.Models;

namespace domain.Logic.Inrefaces
{
    public interface IFlatRepository //: IRepository<Flat> после mvp доработать
    {
        IEnumerable<Flat> GetFlatsByPrice (int price);
        IEnumerable<Flat> GetFlatsByArea (double area);
        IEnumerable<Flat> GetFlatsForYoungFamile();
        IEnumerable<Flat> GetFlatsByWorldeSide(WorldSide worldSide);
    }
}
using domain.Models;

namespace domain.Logic.Inrefaces
{
    public interface IFlatRepository //: IRepository<Flat> после mvp доработать
    {
        Task<IEnumerable<Flat>> GetFlatsByPriceAndArea(int lowPrice, int highPrice, double lowArea, double highArea);
        IEnumerable<Flat> GetFlatsForYoungFamile();
        IEnumerable<Flat> GetFlatsByWindowWorldeSide(WorldSide worldSide);
    }
}
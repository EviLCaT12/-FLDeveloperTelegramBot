using domain.Models;

namespace domain.Logic.Inrefaces
{
    public interface IFlatRepository //: IRepository<Flat> после mvp доработать
    {
        public Task<IEnumerable<Flat>> GetFlatsByPriceAndArea(int lowPrice, int highPrice, double lowArea, double highArea);
        public Task<IEnumerable<Flat>> GetFlatsByWindowWorldeSide(WorldSide worldSide);
        public Task<IEnumerable<Flat>> GetFlatsForYoungFamile(List<InfrastructureObject> infObjects);
    }
}
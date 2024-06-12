using domain.Models;

namespace domain.Logic.Inrefaces
{
    public interface IFlatRepository //: IRepository<Flat> после mvp доработать
    {
        public List<Flat> GetFlatsByPriceAndArea(int lowPrice, int highPrice, double lowArea, double highArea);
        public List<Flat> GetFlatsByWindowWorldeSide(int worldSide);
        public List<Flat> GetFlatsForYoungFamily(List<InfrastructureObject> infObjects);
        public List<InfrastructureObject> GetAllUniqueInfObjects();
    }
}
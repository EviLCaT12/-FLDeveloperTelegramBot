using domain.Logic;
using domain.Logic.Inrefaces;
using domain.Models;

namespace domain.Usecases;
public class FlatService
{
    private readonly IFlatRepository _db;
    public FlatService(IFlatRepository db)
    {
        _db = db;
    }

    public Result<List<Flat>> GetFlatsByPriceAndArea(int lowPrice, int highPrice, double lowArea, double highArea)
    {
        var flats =  _db.GetFlatsByPriceAndArea(lowPrice, highPrice, lowArea, highArea);
        return Result.Ok(flats);
    }

    public Result<List<Flat>> GetFlatsByWindowsSide(WorldSide worldSide)
    {
        var mapWorldSide = Convert.ToInt32(worldSide);
        var flats = _db.GetFlatsByWindowWorldeSide(mapWorldSide);
        return Result.Ok(flats); 
    }

    public Result<List<Flat>> GetFlatsForYoungFamily(List<InfrastructureObject> objects)
    {
        var flats = _db.GetFlatsForYoungFamily(objects);
        return Result.Ok(flats);
        
    }
    
    public Result<List<InfrastructureObject>> GetAllInfrastructureObjects() 
    {
        var infObjects = _db.GetAllUniqueInfObjects();
        return Result.Ok(infObjects);
    }
}
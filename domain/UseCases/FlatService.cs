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
        if (lowPrice < 0 || highPrice < lowPrice)
        {
            return Result.Fail<List<Flat>>("Invalid price");
        }

        if (lowArea <= 0 || highArea < lowArea)
        {
            return Result.Fail<List<Flat>>("Invalid area");
        }

        var flats =  _db.GetFlatsByPriceAndArea(lowPrice, highPrice, lowArea, highArea);
        
        return flats != null ? Result.Ok(flats) : Result.Fail<List<Flat>>("Flats not found");
    }

    public Result<List<Flat>> GetFlatsByWindowsSide(WorldSide worldSide)
    {
        if (!Enum.IsDefined(typeof(WorldSide), worldSide))
            return Result.Fail<List<Flat>>("Unknown enum type"); //maybe useless #Fixme         
        var mapWorldSide = Convert.ToInt32(worldSide);
        var flats = _db.GetFlatsByWindowWorldeSide(mapWorldSide);
        return flats != null ? Result.Ok(flats) : Result.Fail<List<Flat>>("Flats not found"); 
    }

    public Result<List<Flat>> GetFlatsForYoungFamily(List<InfrastructureObject> objects)
    {
        if (objects == null)
            return Result.Fail<List<Flat>>("Empty inf objects list");
        var flats = _db.GetFlatsForYoungFamily(objects);
        return flats != null ? Result.Ok(flats) : Result.Fail<List<Flat>>("Flats not found"); 
        
    }
    
    public Result<List<InfrastructureObject>> GetAllInfrastructureObjects() 
    {
        var infObjects = _db.GetAllUniqueInfObjects();
        return Result.Ok(infObjects);
    }
}
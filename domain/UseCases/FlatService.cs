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
}
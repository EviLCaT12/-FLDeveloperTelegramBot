using DataBase.Models;
using Logic.Models;

namespace DataBase.Converters;

public static class FlatConverter
{
    public static Flat ToDomain(this FlatModel model)
    {
        return new Flat
        {
            Id = model.Id,
            ResidentialComplexId = model.ResidentialComplexId,
            Price = model.Price,
            Area = model.Area,
            RoomQuantity = model.RoomQuantity,
            FloorNumber = model.FloorNumber,
            WorldSide = (WorldSide)model.WorldSide,
            Status = (BuildingStatus)model.Status,
            IsMortgageAvailable = model.IsMortgageAvailable,
            IsSold = model.IsSold
        };
    }

    public static FlatModel ToModel(this Flat model)
    {
        return new FlatModel
        {
            Id = model.Id,
            ResidentialComplexId = model.ResidentialComplexId,
            Price = model.Price,
            Area = model.Area,
            RoomQuantity = model.RoomQuantity,
            FloorNumber = model.FloorNumber,
            WorldSide = (int)model.WorldSide,
            Status = (int)model.Status,
            IsMortgageAvailable = model.IsMortgageAvailable,
            IsSold = model.IsSold
        };
    } 
}
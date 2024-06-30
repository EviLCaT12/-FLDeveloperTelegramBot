using DataBase.Models;
using domain.Models;
using Npgsql;

namespace DataBase.Converters;

public static class FlatConverter
{
    public static Flat ToDomain(NpgsqlDataReader reader)
    {
        return new Flat()
        {
            Id = reader.GetInt32(0),
            ResidentialComplexId = reader.GetInt32(1),
            Price = reader.GetInt32(2),
            Area = reader.GetDouble(3),
            RoomQuantity = reader.GetInt32(4),
            FloorNumber = reader.GetInt32(5),
            WorldSide = (WorldSide)reader.GetInt32(6),
            Status = (BuildingStatus)reader.GetInt32(7),
            IsMortgageAvailable = reader.GetBoolean(8),
            IsSold = reader.GetBoolean(9)
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
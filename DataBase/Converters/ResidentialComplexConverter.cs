using Logic.Models;
using DataBase.Models;

namespace DataBase.Converters;
public static class ResidentialComplexConverter
{
    public static ResidentialComplex ToDomain(this ResidentialComplexModel model)
    {
        return new ResidentialComplex
        {
            Id = model.Id,
            Name = model.Name,
            Adress = model.Adress,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
            HaveLoyalMortgage = model.HaveLoyalMortgage,
            IsFinished = model.IsFinished,
            HaveParkingPlace = model.HaveParkingPlace
        };
    }

    public static ResidentialComplexModel ToModel(this ResidentialComplex model)
    {
        return new ResidentialComplexModel
        {
            Id = model.Id,
            Name = model.Name,
            Adress = model.Adress,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
            HaveLoyalMortgage = model.HaveLoyalMortgage,
            IsFinished = model.IsFinished,
            HaveParkingPlace = model.HaveParkingPlace
        };
    }
}
using Logic.Models;

namespace Logic.Inrefaces
{
    public interface IResidentialComplexRepository : IRepository<ResidentialComplex>
    {
        ResidentialComplex? GetComplexByAdress (string adress);
        ResidentialComplex? GetComplexByСoordinates (double latitude, double longitude);
        ResidentialComplex? GetComplexByName (string name);
    }
}
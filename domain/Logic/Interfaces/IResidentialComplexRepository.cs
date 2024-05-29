using domain.Models;

namespace domain.Logic.Inrefaces
{
    public interface IResidentialComplexRepository //: IRepository<ResidentialComplex> TODO после mvp доработать
    {
        ResidentialComplex? GetComplexByAdress (string adress);
        ResidentialComplex? GetComplexByСoordinates (double latitude, double longitude);
        ResidentialComplex? GetComplexByName (string name);
    }
}
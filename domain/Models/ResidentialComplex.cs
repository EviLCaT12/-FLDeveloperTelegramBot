using domain.Logic;

namespace domain.Models
{
    public class ResidentialComplex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<InfrastructureObject> InfrastructureObjects { get; set; }
        public bool HaveParkingPlace { get; set; }
        public bool IsFinished { get; set; }
        public bool HaveLoyalMortgage { get; set; }


        public Result IsValid()
        {
            if (Id <= 0)
                return Result.Fail("Invalid id");

            if (string.IsNullOrEmpty(Name))
                return Result.Fail("Invalid name");

            if (string.IsNullOrEmpty(Adress))
                return Result.Fail("Invalid adres");

            return Result.Ok();
        }
    }

}
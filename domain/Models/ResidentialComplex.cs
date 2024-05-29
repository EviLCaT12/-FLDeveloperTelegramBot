namespace Logic.Models
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
    }

}
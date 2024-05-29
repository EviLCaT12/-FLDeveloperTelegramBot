
namespace domain.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public int ResidentialComplexId { get; set; }
        public int Price { get; set; }
        public double Area { get; set; }
        public int RoomQuantity { get; set; }
        public int FloorNumber { get; set; }
        public WorldSide WorldSide{ get; set; }
        public BuildingStatus Status { get; set; }
        public bool IsMortgageAvailable { get; set; }
        public bool IsSold { get; set; }
    }
    
    public enum WorldSide
    {
        North,
        South,
        West,
        East
    }

    public enum BuildingStatus
    {
        WithOutFinishing,
        PreFinishing,
        Finishing
    }
}

using Logic.Models;

namespace DataBase.Models
{
    public class FlatModel
    {
        public int Id { get; set; }
        public int ResidentialComplexId { get; set; }
        public int Price { get; set; }
        public double Area { get; set; }
        public int RoomQuantity { get; set; }
        public int FloorNumber { get; set; }
        public int WorldSide{ get; set; }
        public int Status { get; set; }
        public bool IsMortgageAvailable { get; set; }
        public bool IsSold { get; set; }
    }
}
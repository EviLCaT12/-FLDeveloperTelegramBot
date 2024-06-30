
using domain.Logic;

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


        public Result IsValid()
        {
            if (Id < 0)
                return Result.Fail("Invalid id");

            if (ResidentialComplexId < 0 )
                return Result.Fail("Invalid residential complex id");

            if (Price <= 0 )
                return Result.Fail("Invalid price");
            
            if (Area < 0 )
                return Result.Fail("Invalid area");

            if (RoomQuantity <= 0 )
                return Result.Fail("Invalid room quantity");
                
            if (FloorNumber == 0 )
                return Result.Fail("Invalid floot number");

            return Result.Ok();
        }

        
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
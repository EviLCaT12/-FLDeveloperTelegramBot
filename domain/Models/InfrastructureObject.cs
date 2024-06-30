using domain.Logic;

namespace domain.Models
{
    public class InfrastructureObject //TODO может стоит enum
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Result IsValid()
        {
            if (Id <= 0)
                return Result.Fail("Invalid id");

            if (string.IsNullOrEmpty(Name))
                return Result.Fail("Invalid name");

            return Result.Ok();
        }
    }
}
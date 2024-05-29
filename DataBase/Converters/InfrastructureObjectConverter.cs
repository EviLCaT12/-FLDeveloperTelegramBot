using Logic.Models;
using DataBase.Models;

namespace DataBase.Converters;

public static class InfrastructureObjectConverter
{
    public static InfrastructureObject ToDomain(this InfrastructureObjectModel model)
    {
        return new InfrastructureObject
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    public static InfrastructureObjectModel ToModel(this InfrastructureObject model)
    {
        return new InfrastructureObjectModel
        {
            Id = model.Id,
            Name = model.Name
        };
    }
}
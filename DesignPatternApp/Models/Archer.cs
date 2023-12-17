using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Models;

internal class Archer : Character
{
    public Archer(IRoleAttributes attributes)
    {
        AddRole(attributes);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Archer - " +
                          $"Health: {Health}, " +
                          $"Location: ({Location.Longitude}, {Location.Latitude}), " +
                          $"Roles: {GetRoleAttributeNames()}, " +
                          $"Experience: {Experience}");
    }
}
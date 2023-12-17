using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Models;

internal class Warrior : Character
{
    public Warrior(IRoleAttributes attributes)
    {
        AddRole(attributes);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Warrior - " +
                          $"Health: {Health}, " +
                          $"Location: ({Location.Longitude}, {Location.Latitude}), " +
                          $"Roles: {GetRoleAttributeNames()}, " +
                          $"Experience: {Experience}");
    }
}
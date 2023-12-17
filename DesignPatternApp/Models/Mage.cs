using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Models;

internal class Mage : Character
{
    public Mage(IRoleAttributes attributes)
    {
        AddRole(attributes);
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Mage - " +
                          $"Health: {Health}, " +
                          $"Location: ({Location.Longitude}, {Location.Latitude}), " +
                          $"Role attributes: {GetRoleAttributeNames()}, " +
                          $"Experience: {Experience}");
    }

    public void Teleport(Location coordinates)
    {
        Location = coordinates;
        Console.WriteLine($"Character has teleported to ({coordinates.Latitude}, {coordinates.Longitude})");
    }
}
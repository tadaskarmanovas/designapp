using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Models;

internal abstract class Character
{
    public int Health { get; set; } = 100;
    public int Experience { get; set; } = 10;
    public int Strength { get; set; }
    public int Agility { get; set; }
    public int Magic { get; set; }

    private List<IRoleAttributes> RoleAttributes { get; } = new();
    public Location Location { get; set; } = new();

    public abstract void DisplayInfo();

    public string GetRoleAttributeNames()
    {
        return string.Join(", ", RoleAttributes.Select(x => x.GetType().Name));
    }

    public void AddRole(IRoleAttributes attributes)
    {
        RoleAttributes.Add(attributes);

        Strength += attributes.Strength;
        Magic += attributes.Magic;
        Agility += attributes.Agility;

        Experience -= 10;
    }

    public Location Attack(Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Location { Latitude = Location.Latitude + 1, Longitude = Location.Longitude },
            Direction.Down => new Location { Latitude = Location.Latitude - 1, Longitude = Location.Longitude },
            Direction.Left => new Location { Latitude = Location.Latitude, Longitude = Location.Longitude + 1 },
            Direction.Right => new Location { Latitude = Location.Latitude, Longitude = Location.Longitude - 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                Location.Latitude++;
                break;

            case Direction.Down:
                Location.Latitude--;
                break;

            case Direction.Left:
                Location.Longitude++;
                break;

            case Direction.Right:
                Location.Longitude--;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public void RemoveRole(Type type)
    {
        var role = RoleAttributes.SingleOrDefault(x => x.GetType() == type);

        if (role != null)
        {
            Magic -= role.Magic;
            Strength -= role.Strength;
            Agility -= role.Agility;
            Experience += 10;
        }

        RoleAttributes.Remove(role);
    }
}
using DesignPatternApp.Attributes;
using DesignPatternApp.Commands;
using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp;

internal class CommandParser
{
    public static MoveCommand GetMoveCommand(IReadOnlyList<string> action, Character character)
    {
        if (Enum.TryParse(action[1], true, out Direction stepDirection))
        {
            return new MoveCommand(character, stepDirection);
        }

        throw new Exception($"Incorrect input. Character {character.GetType().Name} has missed his turn");
    }

    public static HitCommand GetHitCommand(List<Character> characters, IReadOnlyList<string> action, Character character)
    {
        if (!Enum.TryParse(action[1], true, out Direction hitDirection))
            throw new Exception($"Incorrect input. Character {character.GetType().Name} has missed his turn");

        var hitLocation = character.Attack(hitDirection);
        return new HitCommand(hitLocation, characters, character);
    }

    public static AddRoleCommand GetAddRoleCommand(IReadOnlyList<string> action, Character character)
    {
        var newType = action[1];
        if (character.Experience <= 10) throw new Exception($"Character {character.GetType().Name} does not have enough experience to get new role");

        return newType.ToLower() switch
        {
            "warrior" => new AddRoleCommand(character, new WarriorAttributes()),
            "mage" => new AddRoleCommand(character, new MageAttributes()),
            "archer" => new AddRoleCommand(character, new ArcherAttributes()),
            _ => throw new Exception("Failed to parse add role command")
        };
    }

    public static ICommand GetRemoveRoleCommand(string[] action, Character character)
    {
        var newType = action[1];

        return newType.ToLower() switch
        {
            "warrior" => new RemoveRoleCommand(character, typeof(WarriorAttributes)),
            "mage" => new RemoveRoleCommand(character, typeof(MageAttributes)),
            "archer" => new RemoveRoleCommand(character, typeof(ArcherAttributes)),
            _ => throw new Exception("Failed to parse remove role command")
        };
    }

    public static TeleportCommand GetTeleportCommand(IReadOnlyList<string> action, Character character)
    {
        if (character.Magic == 0 && character is not Mage)
        {
            throw new Exception("Only mages are able to do special actions");
        }

        if (!int.TryParse(action[1], out var x) || !int.TryParse(action[2], out var y))
        {
            throw new Exception("Failed to parse teleport command");
        }

        var coordinates = new Location { Latitude = x, Longitude = y };

        if ((Math.Sqrt(
                Math.Pow((character.Location.Latitude - coordinates.Latitude), 2) +
                Math.Pow((character.Location.Longitude - coordinates.Longitude), 2)) < 5))
        {
            return new TeleportCommand((Mage)character, coordinates);
        }

        throw new Exception("Teleportation so far is not allowed");
    }
}
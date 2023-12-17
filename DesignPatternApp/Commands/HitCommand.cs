using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp.Commands;

internal class HitCommand : ICommand
{
    private readonly Location _hitLocation;
    private readonly List<Character> _characters;
    private readonly Character _character;

    public HitCommand(Location hitLocation, List<Character> characters, Character character)
    {
        _hitLocation = hitLocation;
        _characters = characters;
        _character = character;
    }

    public void Execute()
    {
        foreach (var character in _characters.Where(character => character.Location.Latitude == _hitLocation.Latitude &&
                                                                 character.Location.Longitude == _hitLocation.Longitude))
        {
            character.Health -= _character.Strength;
        }
    }
}
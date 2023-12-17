using DesignPatternApp.Creators;
using DesignPatternApp.Models;

namespace DesignPatternApp;

internal class Initializer
{
    public static List<Character> InitializeCharacters()
    {
        var characterCreators = new List<CharacterCreator>()
        {
            new MageCreator(),
            new ArcherCreator(),
            new WarriorCreator()
        };

        return characterCreators.Select(x =>
        {
            var character = x.FactoryMethod();
            character.DisplayInfo();
            return character;
        }).ToList();
    }
}
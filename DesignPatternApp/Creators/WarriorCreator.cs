using DesignPatternApp.Attributes;
using DesignPatternApp.Models;

namespace DesignPatternApp.Creators;

internal class WarriorCreator : CharacterCreator
{
    public override Character FactoryMethod()
    {
        return new Warrior(new WarriorAttributes());
    }
}
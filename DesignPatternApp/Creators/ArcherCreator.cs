using DesignPatternApp.Attributes;
using DesignPatternApp.Models;

namespace DesignPatternApp.Creators;

internal class ArcherCreator : CharacterCreator
{
    public override Character FactoryMethod()
    {
        return new Archer(new ArcherAttributes());
    }
}
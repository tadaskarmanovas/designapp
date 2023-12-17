using DesignPatternApp.Attributes;
using DesignPatternApp.Models;

namespace DesignPatternApp.Creators;

internal class MageCreator : CharacterCreator
{
    public override Character FactoryMethod()
    {
        return new Mage(new MageAttributes());
    }
}
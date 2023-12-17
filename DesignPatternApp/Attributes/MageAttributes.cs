using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Attributes;

internal class MageAttributes : IRoleAttributes
{
    public int Strength { get; set; } = 2;
    public int Magic { get; set; } = 15;
    public int Agility { get; set; } = 3;
}
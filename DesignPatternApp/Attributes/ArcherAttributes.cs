using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Attributes;

internal class ArcherAttributes : IRoleAttributes
{
    public int Strength { get; set; } = 3;
    public int Magic { get; set; } = 0;

    public int Agility { get; set; } = 20;
}
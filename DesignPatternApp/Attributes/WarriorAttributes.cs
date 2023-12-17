using DesignPatternApp.Interfaces;

namespace DesignPatternApp.Attributes;

internal class WarriorAttributes : IRoleAttributes
{
    public int Strength { get; set; } = 10;
    public int Magic { get; set; } = 0;
    public int Agility { get; set; } = 5;
}
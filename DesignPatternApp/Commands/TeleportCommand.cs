using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp.Commands;

internal class TeleportCommand : ICommand
{
    private readonly Mage _mage;
    private readonly Location _location;

    public TeleportCommand(Mage mage, Location location)
    {
        _mage = mage;
        _location = location;
    }

    public void Execute()
    {
        _mage.Teleport(_location);
    }
}
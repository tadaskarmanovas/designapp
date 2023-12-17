using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp.Commands;

internal class RemoveRoleCommand : ICommand
{
    private readonly Character _character;
    private readonly Type _type;

    public RemoveRoleCommand(Character character, Type type)
    {
        _character = character;
        _type = type;
    }

    public void Execute()
    {
        _character.RemoveRole(_type);
    }
}
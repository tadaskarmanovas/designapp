using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp.Commands;

internal class AddRoleCommand : ICommand
{
    private readonly Character _character;
    private readonly IRoleAttributes _attributes;

    public AddRoleCommand(Character character, IRoleAttributes attributes)
    {
        _character = character;
        _attributes = attributes;
    }

    public void Execute()
    {
        _character.AddRole(_attributes);
    }
}
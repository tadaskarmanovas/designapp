using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp.Commands;

internal class MoveCommand : ICommand
{
    private readonly Character _character;
    private readonly Direction _stepDirection;

    public MoveCommand(Character character, Direction stepDirection)
    {
        _character = character;
        _stepDirection = stepDirection;
    }

    public void Execute()
    {
        _character.Move(_stepDirection);
    }
}
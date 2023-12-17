using DesignPatternApp.Interfaces;

namespace DesignPatternApp;

internal class CommandInvoker
{
    public void Invoke(ICommand command)
    {
        Console.WriteLine($"Command {command.GetType().Name} has been invoked");
        command.Execute();
    }
}
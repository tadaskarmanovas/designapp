using DesignPatternApp.Interfaces;
using DesignPatternApp.Models;

namespace DesignPatternApp;

internal class StartUpService
{
    public static void Run(List<Character> characters)
    {
        Console.WriteLine();
        Console.WriteLine("This is a turn-based role play game. Each player takes turns. ");
        Console.WriteLine("Players can move, hit an enemy, or morph to different role.");
        Console.WriteLine("To control write action and direction, for example 'Move Up' or 'Hit Down'.");
        Console.WriteLine();

        var commandInvoker = new CommandInvoker();

        while (true)
        {
            foreach (var character in characters)
            {
                try
                {
                    Console.WriteLine($"This is player's {character.GetType().Name} turn.");
                    character.DisplayInfo();
                    Console.WriteLine();

                    var readLine = Console.ReadLine();
                    if (readLine != null)
                    {
                        var input = readLine.Split(' ');
                        var command = ProcessInput(characters, character, input);

                        if (command is not null)
                        {
                            commandInvoker.Invoke(command);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                character.Experience++;
                Console.WriteLine();
            }
        }
    }

    private static ICommand ProcessInput(List<Character> characters, Character character, string[] input)
    {
        return input[0].ToLower() switch
        {
            "move" => CommandParser.GetMoveCommand(input, character),
            "hit" => CommandParser.GetHitCommand(characters, input, character),
            "teleport" => CommandParser.GetTeleportCommand(input, character),
            "upgrade" => CommandParser.GetAddRoleCommand(input, character),
            "degrade" => CommandParser.GetRemoveRoleCommand(input, character),
            _ => throw new Exception($"Incorrect input. Character {character.GetType().Name} has missed his turn")
        };
    }
}
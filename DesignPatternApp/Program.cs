namespace DesignPatternApp;

internal class Program
{
    private static void Main()
    {
        var characters = Initializer.InitializeCharacters();

        StartUpService.Run(characters);
    }
}
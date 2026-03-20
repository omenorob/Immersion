namespace Immersion;

public class ConsoleInput : IInput
{
    public string ReadLine() => Console.ReadLine();
    public void ReadKey() => Console.ReadKey();
}
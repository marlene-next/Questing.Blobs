using System.Text;

namespace blobs.Presentation;

public class InputHandler
{
    private readonly Dictionary<ConsoleKey, string> _registeredKeys = new();

    public static InputHandler Create()
    {
        return new InputHandler();
    }

    public InputHandler Add(ConsoleKey character, string label)
    {
        _registeredKeys.Add(character, label);
        return this;
    }

    public ConsoleKey WaitForKey()
    {
        if (!_registeredKeys.Any())
            throw new InvalidOperationException("Prompt for input with no registered keys.");

        var prompt = GetRegisteredKeysPrompt();

        Console.WriteLine(prompt);

        ConsoleKey key;
        do
        {
            key = ReadKey();
        } while (!_registeredKeys.ContainsKey(key));

        Console.WriteLine($"... {_registeredKeys[key]}{Environment.NewLine}");
        return key;
    }

    private string GetRegisteredKeysPrompt()
    {
        var sb = new StringBuilder();
        foreach (var (key, label) in _registeredKeys)
        {
            sb.Append($"[{key}] {label} ");
        }

        return sb.ToString();
    }

    private static ConsoleKey ReadKey()
    {
        return Console.ReadKey(true).Key;
    }
}
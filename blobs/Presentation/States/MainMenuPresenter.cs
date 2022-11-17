using blobs.Application;

namespace blobs.Presentation.States;

public class MainMenuPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;

    public MainMenuPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }

    public void Present()
    {
        Console.WriteLine(nameof(MainMenuPresenter));

        Console.WriteLine("[X] explore, [Q] quit");
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Q)
        {
            _stateMachine.Close();
        }
        else if (input.Key == ConsoleKey.X)
        {
            var blob = new BlobViewModel("Grogo");
            Console.WriteLine($"Found {blob.Name}");
        }
    }
}
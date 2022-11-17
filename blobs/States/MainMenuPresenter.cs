namespace blobs.States;

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

        Console.WriteLine("[Q] quit");
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Q)
            _stateMachine.Close();
    }
}
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

    public void Initialize(IViewModel viewModel) { }

    public void Present()
    {
        Console.WriteLine(nameof(MainMenuPresenter));

        Console.WriteLine("[X] explore, [B] blobdex, [Q] quit");
        var input = Console.ReadKey();
        switch (input.Key)
        {
            case ConsoleKey.X:
            {
                var blob = new BlobViewModel("Grogo");
                Console.WriteLine($"Found blob: {blob.Name}");
                _stateMachine.ChangeState(StateNameConstants.EncounterState, blob);
                break;
            }
            case ConsoleKey.B:
                _stateMachine.ChangeState(StateNameConstants.BlobdexState);
                break;
            case ConsoleKey.Q:
                _stateMachine.Close();
                break;
        }
    }
}
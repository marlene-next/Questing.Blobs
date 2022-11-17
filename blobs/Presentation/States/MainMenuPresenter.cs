using blobs.Application;

namespace blobs.Presentation.States;

public class MainMenuPresenter : PresenterBase
{
    public MainMenuPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Present()
    {
        Console.WriteLine(nameof(MainMenuPresenter));

        Console.WriteLine("[X] explore, [B] blobdex, [Q] quit");
        var input = Console.ReadKey();
        switch (input.Key)
        {
            case ConsoleKey.X:
            {
                var blob = new BlobViewModel("Grogo", 100);
                Console.WriteLine($"Found blob: {blob.Name}");
                StateMachine.ChangeState(StateNameConstants.EncounterState, blob);
                break;
            }
            case ConsoleKey.B:
                StateMachine.ChangeState(StateNameConstants.BlobdexState);
                break;
            case ConsoleKey.Q:
                StateMachine.Close();
                break;
        }
    }
}
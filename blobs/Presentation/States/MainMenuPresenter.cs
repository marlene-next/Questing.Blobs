namespace blobs.Presentation.States;

public class MainMenuPresenter : PresenterBase
{
    public MainMenuPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Present()
    {
        Console.WriteLine("[X] explore, [B] blobdex, [Q] quit");
        var input = Console.ReadKey();
        switch (input.Key)
        {
            case ConsoleKey.X:
                StateMachine.ChangeState(StateNameConstants.ExplorationState);
                break;
            case ConsoleKey.B:
                StateMachine.ChangeState(StateNameConstants.BlobdexState);
                break;
            case ConsoleKey.Q:
                StateMachine.Close();
                break;
        }
    }
}
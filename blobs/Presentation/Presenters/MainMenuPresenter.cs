using blobs.Application;
using blobs.Presentation.States;
using blobs.Presentation.Views;

namespace blobs.Presentation.Presenters;

public class MainMenuPresenter : PresenterBase<StubView>
{
    private InputHandler _inputHandler;

    public MainMenuPresenter(IStateMachine stateMachine, StubView view) : base(stateMachine, view) { }

    public override void Initialize(IViewModel viewModel)
    {
        _inputHandler = InputHandler.Create()
            .Add(ConsoleKey.X, "explore")
            .Add(ConsoleKey.B, "blobdex")
            .Add(ConsoleKey.Q, "quit");
    }

    public override void Present()
    {
        switch (_inputHandler.WaitForKey())
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
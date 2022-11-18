using blobs.Application;

namespace blobs.Presentation.States;

public class BlobdexPresenter : PresenterBase
{
    private InputHandler _inputHandler;

    public BlobdexPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Initialize(IViewModel viewModel)
    {
        _inputHandler = InputHandler.Create().Add(ConsoleKey.B, "back");
    }

    public override void Present()
    {
        Console.WriteLine(nameof(BlobdexPresenter));

        var key = _inputHandler.WaitForKey();
        if (key == ConsoleKey.B)
            StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
using blobs.Application;

namespace blobs.Presentation.States;

public class BlobdexPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;
    private InputHandler _inputHandler;

    public BlobdexPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }

    public void Initialize(IViewModel viewModel)
    {
        _inputHandler = InputHandler.Create().Add(ConsoleKey.B, "back");
    }

    public void Present()
    {
        Console.WriteLine(nameof(BlobdexPresenter));

        var key = _inputHandler.WaitForKey();
        if (key == ConsoleKey.B)
            _stateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
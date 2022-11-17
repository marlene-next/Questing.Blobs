using blobs.Application;

namespace blobs.Presentation.States;

public class BlobdexPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;

    public BlobdexPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }

    public void Initialize(IViewModel viewModel) { }

    public void Present()
    {
        Console.WriteLine(nameof(BlobdexPresenter));

        Console.WriteLine("[B] back");
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.B)
            _stateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
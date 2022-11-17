using blobs.Application;

namespace blobs.Presentation.States;

public class FightResultsPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;
    
    public FightResultsPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }
    
    public void Initialize(IViewModel viewModel) {}

    public void Present()
    {
        Console.WriteLine("Your pokemon gained XP:");
        _stateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
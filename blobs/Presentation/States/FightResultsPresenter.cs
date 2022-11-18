using blobs.Application;

namespace blobs.Presentation.States;

public class FightResultsPresenter : PresenterBase
{
    public FightResultsPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Initialize(IViewModel viewModel) { }

    public override void Present()
    {
        Console.WriteLine("Your pokemon gained XP:");
        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
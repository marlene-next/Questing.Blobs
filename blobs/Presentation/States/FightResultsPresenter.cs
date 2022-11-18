using blobs.Application;
using blobs.Presentation.Views;

namespace blobs.Presentation.States;

public class FightResultsPresenter : PresenterBase<StubView>
{
    public FightResultsPresenter(IStateMachine stateMachine, StubView stubView) : base(stateMachine, stubView) { }

    public override void Initialize(IViewModel viewModel) { }

    public override void Present()
    {
        Console.WriteLine("Your pokemon gained XP:");
        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
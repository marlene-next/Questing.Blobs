using blobs.Application;
using blobs.Presentation.States;
using blobs.Presentation.Views;

namespace blobs.Presentation.Presenters;

public class FightResultsPresenter : PresenterBase<StubView>
{
    public FightResultsPresenter(IStateMachine stateMachine, StubView stubView) : base(stateMachine, stubView) { }

    public override void Initialize(IViewModel viewModel) { }

    public override void Present()
    {
        Console.WriteLine("Your blob gained XP: 5");
        Console.WriteLine();

        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
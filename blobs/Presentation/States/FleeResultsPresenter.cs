using blobs.Application;
using blobs.Presentation.Views;

namespace blobs.Presentation.States;

public class FleeResultsPresenter : PresenterBase<StubView>
{
    public FleeResultsPresenter(IStateMachine stateMachine, StubView view) : base(stateMachine, view) { }

    public override void Initialize(IViewModel viewModel) { }

    public override void Present()
    {
        Console.WriteLine("You fled...");
        Console.WriteLine();

        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
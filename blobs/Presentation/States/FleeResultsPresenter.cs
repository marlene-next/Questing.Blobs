namespace blobs.Presentation.States;

public class FleeResultsPresenter : PresenterBase
{
    public FleeResultsPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Present()
    {
        Console.WriteLine("You fled...");
        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
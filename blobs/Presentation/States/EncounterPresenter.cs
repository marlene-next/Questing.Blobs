namespace blobs.Presentation.States;

public class EncounterPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;

    public EncounterPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }

    public void Present()
    {
        Console.WriteLine(nameof(EncounterPresenter));
    }
}
using blobs.Application;

namespace blobs.Presentation.States;

public class EncounterPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;
    private BlobViewModel _blob;

    public EncounterPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }

    public void Initialize(IViewModel viewModel)
    {
        viewModel.ThrowIfNull(nameof(viewModel));
        _blob = (BlobViewModel) viewModel;
    }

    public void Present()
    {
        Console.WriteLine(nameof(EncounterPresenter));
        Console.WriteLine($"{_blob.Name}");
        Console.WriteLine("[A] attack");

        var input = Console.ReadKey();

        if (input.Key == ConsoleKey.A)
        {
            _stateMachine.ChangeState(StateNameConstants.FightResultsState);
        }
    }
}
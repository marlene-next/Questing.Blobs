using blobs.Application;

namespace blobs.Presentation.States;

public class EncounterPresenter : PresenterBase
{
    private BlobViewModel _blob;

    public EncounterPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Initialize(IViewModel viewModel)
    {
        viewModel.ThrowIfNull(nameof(viewModel));
        _blob = (BlobViewModel) viewModel;
    }

    public override void Present()
    {
        Console.WriteLine($"{_blob.Name}");
        Console.WriteLine("[A] attack, [C] catch, [F] flee");

        var input = Console.ReadKey();

        if (input.Key == ConsoleKey.A)
        {
            if (_blob.Health > 0)
            {
                Present();
                return;
            }
            
            StateMachine.ChangeState(StateNameConstants.FightResultsState);
        }
        else if (input.Key == ConsoleKey.C)
        {
            StateMachine.ChangeState(StateNameConstants.CatchResultsState, _blob);
        }
        else if (input.Key == ConsoleKey.F)
        {
            StateMachine.ChangeState(StateNameConstants.FleeResultsState);
        }
    }
}
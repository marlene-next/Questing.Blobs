using blobs.Application;

namespace blobs.Presentation.States;

public class CatchResultsPresenter : PresenterBase
{
    private BlobViewModel _blob;
    
    public CatchResultsPresenter(IStateMachine stateMachine) : base(stateMachine) { }

    public override void Initialize(IViewModel viewModel)
    {
        viewModel.ThrowIfNull(nameof(viewModel));
        
        _blob = (BlobViewModel)viewModel;
    }

    public override void Present()
    {
        Console.WriteLine($"Caught {_blob.Name}!");
        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
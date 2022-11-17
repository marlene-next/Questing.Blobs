using blobs.Application;

namespace blobs.Presentation.States;

public class CatchResultsPresenter : IPresenter
{
    private readonly IStateMachine _stateMachine;
    
    private BlobViewModel _blob;
    
    public CatchResultsPresenter(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        _stateMachine = stateMachine;
    }
    
    public void Initialize(IViewModel viewModel)
    {
        viewModel.ThrowIfNull(nameof(viewModel));
        
        _blob = (BlobViewModel)viewModel;
    }

    public void Present()
    {
        Console.WriteLine($"Caught {_blob.Name}!");
        _stateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
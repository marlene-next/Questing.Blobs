using blobs.Application;
using blobs.Presentation.Views;

namespace blobs.Presentation.States;

public class CatchResultsPresenter : PresenterBase<StubView>
{
    private BlobViewModel _blob;

    public CatchResultsPresenter(IStateMachine stateMachine, StubView view) : base(stateMachine, view) { }

    public override void Initialize(IViewModel viewModel)
    {
        viewModel.ThrowIfNull(nameof(viewModel));

        _blob = (BlobViewModel) viewModel;
    }

    public override void Present()
    {
        Console.WriteLine($"Caught {_blob.Name}!");
        Console.WriteLine();

        StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
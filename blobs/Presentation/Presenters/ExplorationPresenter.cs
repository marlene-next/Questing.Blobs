using blobs.Application;
using blobs.Presentation.States;
using blobs.Presentation.Views;

namespace blobs.Presentation.Presenters;

public class ExplorationPresenter : PresenterBase<ExplorationView>
{
    private readonly IEncounteredBlobStorage _encounteredBlobStorage;
    private readonly IBlobDefinitionProvider _blobDefinitionProvider;

    public ExplorationPresenter(IStateMachine stateMachine, ExplorationView view, 
        IEncounteredBlobStorage encounteredBlobStorage, IBlobDefinitionProvider blobDefinitionProvider) :
        base(stateMachine, view)
    {
        encounteredBlobStorage.ThrowIfNull(nameof(encounteredBlobStorage));
        blobDefinitionProvider.ThrowIfNull(nameof(blobDefinitionProvider));

        _encounteredBlobStorage = encounteredBlobStorage;
        _blobDefinitionProvider = blobDefinitionProvider;
    }

    public override void Initialize(IViewModel viewModel) { }

    public override void Present()
    {
        var findBlobCommand = new DiscoverBlobCommand(_encounteredBlobStorage, _blobDefinitionProvider);
        findBlobCommand.Execute();

        var foundBlobQuery = new DiscoveredBlobQuery(_encounteredBlobStorage);
        var blob = foundBlobQuery.Run();

        View.ShowBlobFound(blob);
        
        StateMachine.ChangeState(StateNameConstants.EncounterState, blob);
    }
}
using blobs.Application;

namespace blobs.Presentation.States;

public class ExplorationPresenter : PresenterBase
{
    private readonly IEncounteredBlobStorage _encounteredBlobStorage;
    private readonly IBlobDefinitionProvider _blobDefinitionProvider;

    public ExplorationPresenter(IStateMachine stateMachine, IEncounteredBlobStorage encounteredBlobStorage,
        IBlobDefinitionProvider blobDefinitionProvider) : base(stateMachine)
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

        Console.WriteLine($"Found blob: {blob.Name}");
        StateMachine.ChangeState(StateNameConstants.EncounterState, blob);
    }
}
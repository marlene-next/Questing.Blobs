using blobs.Application;

namespace blobs.Presentation.States;

public class ExplorationPresenter : PresenterBase
{
    private readonly IEncounteredBlobStorage _encounteredBlobStorage;

    public ExplorationPresenter(IEncounteredBlobStorage encounteredBlobStorage, IStateMachine stateMachine) : base(stateMachine)
    {
        encounteredBlobStorage.ThrowIfNull(nameof(encounteredBlobStorage));

        _encounteredBlobStorage = encounteredBlobStorage;
    }

    public override void Present()
    {
        var findBlobCommand = new FindBlobCommand(_encounteredBlobStorage);
        findBlobCommand.Execute();

        var foundBlobQuery = new FoundBlobQuery(_encounteredBlobStorage);
        var blob = foundBlobQuery.Run();

        Console.WriteLine($"Found blob: {blob.Name}");
        StateMachine.ChangeState(StateNameConstants.EncounterState, blob);
    }
}
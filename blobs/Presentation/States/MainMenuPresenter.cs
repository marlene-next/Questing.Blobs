using blobs.Application;

namespace blobs.Presentation.States;

public class MainMenuPresenter : PresenterBase
{
    private readonly IEncounteredBlobStorage _encounteredBlobStorage;
    
    public MainMenuPresenter(IEncounteredBlobStorage encounteredBlobStorage, IStateMachine stateMachine) :
        base(stateMachine)
    {
        encounteredBlobStorage.ThrowIfNull(nameof(encounteredBlobStorage));

        _encounteredBlobStorage = encounteredBlobStorage;
    }

    public override void Present()
    {
        Console.WriteLine(nameof(MainMenuPresenter));

        Console.WriteLine("[X] explore, [B] blobdex, [Q] quit");
        var input = Console.ReadKey();
        switch (input.Key)
        {
            case ConsoleKey.X:
            {
                var findBlobCommand = new FindBlobCommand(_encounteredBlobStorage);
                findBlobCommand.Execute();

                var foundBlobQuery = new FoundBlobQuery(_encounteredBlobStorage);
                var blob = foundBlobQuery.Run();
                
                Console.WriteLine($"Found blob: {blob.Name}");
                StateMachine.ChangeState(StateNameConstants.EncounterState, blob);
                break;
            }
            case ConsoleKey.B:
                StateMachine.ChangeState(StateNameConstants.BlobdexState);
                break;
            case ConsoleKey.Q:
                StateMachine.Close();
                break;
        }
    }
}
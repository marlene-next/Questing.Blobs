using blobs.Application;

namespace blobs.Presentation.States;

public class BlobdexPresenter : PresenterBase
{
    private InputHandler _inputHandler;
    private IBlobInventoryStorage _blobInventoryStorage;
    private ICaughtBlobStorage _caughtBlobStorage;

    public BlobdexPresenter(IStateMachine stateMachine, IBlobInventoryStorage blobInventoryStorage,
        ICaughtBlobStorage caughtBlobStorage) : base(stateMachine)
    {
        blobInventoryStorage.ThrowIfNull(nameof(blobInventoryStorage));
        caughtBlobStorage.ThrowIfNull(nameof(caughtBlobStorage));

        _blobInventoryStorage = blobInventoryStorage;
        _caughtBlobStorage = caughtBlobStorage;
    }

    public override void Initialize(IViewModel viewModel)
    {
        _inputHandler = InputHandler.Create().Add(ConsoleKey.B, "back");
    }

    public override void Present()
    {
        var getOwnedBlobsQuery = new GetOwnedBlobsQuery(_blobInventoryStorage, _caughtBlobStorage);
        var ownedBlobsViewModel = getOwnedBlobsQuery.Run();

        if (!ownedBlobsViewModel.OwnedBlobs.Any())
            Console.WriteLine("No blobs caught yet.");

        foreach (var blobViewModel in ownedBlobsViewModel.OwnedBlobs)
            Console.WriteLine(blobViewModel.ToString());

        var key = _inputHandler.WaitForKey();
        if (key == ConsoleKey.B)
            StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
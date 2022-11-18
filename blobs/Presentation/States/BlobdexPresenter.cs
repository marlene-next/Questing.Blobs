using blobs.Application;
using blobs.Presentation.Views;

namespace blobs.Presentation.States;

public class BlobdexPresenter : PresenterBase<StubView>
{
    private InputHandler _inputHandler;
    private IBlobInventoryStorage _blobInventoryStorage;
    private ICaughtBlobStorage _caughtBlobStorage;

    public BlobdexPresenter(IStateMachine stateMachine, StubView view, IBlobInventoryStorage blobInventoryStorage,
        ICaughtBlobStorage caughtBlobStorage) : base(stateMachine, view)
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
        {
            Console.WriteLine("No blobs caught yet.");
            Console.WriteLine();
        }

        foreach (var blobViewModel in ownedBlobsViewModel.OwnedBlobs)
        {
            Console.WriteLine(blobViewModel.ToString());
        }

        var key = _inputHandler.WaitForKey();
        if (key == ConsoleKey.B)
            StateMachine.ChangeState(StateNameConstants.MainMenuState);
    }
}
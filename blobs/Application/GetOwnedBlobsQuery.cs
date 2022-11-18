namespace blobs.Application;

public class GetOwnedBlobsQuery : IQuery<OwnedBlobsViewModel>
{
    private readonly IBlobInventoryStorage _blobInventoryStorage;
    private readonly ICaughtBlobStorage _caughtBlobStorage;

    public GetOwnedBlobsQuery(IBlobInventoryStorage blobInventoryStorage, ICaughtBlobStorage caughtBlobStorage)
    {
        blobInventoryStorage.ThrowIfNull(nameof(blobInventoryStorage));

        _blobInventoryStorage = blobInventoryStorage;
        _caughtBlobStorage = caughtBlobStorage;
    }

    public OwnedBlobsViewModel Run()
    {
        var inventory = _blobInventoryStorage.GetInventory();
        var blobIds = inventory.GetOwnedBlobIds();

        var blobModels = _caughtBlobStorage.GetBlobModels(blobIds);

        var ownedBlobViewModels = blobModels.Select(blobModel =>
            new OwnedBlobViewModel(blobModel.Id, blobModel.Name, blobModel.Health));

        var ownedBlobsViewModel = new OwnedBlobsViewModel(ownedBlobViewModels);
        return ownedBlobsViewModel;
    }
}
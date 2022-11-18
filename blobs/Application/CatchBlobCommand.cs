using blobs.Domain;

namespace blobs.Application;

public class CatchBlobCommand : ICommand
{
    private readonly IEncounteredBlobStorage _encounteredBlobStorage;
    private readonly Guid _encounteredBlobId;
    private readonly IBlobInventoryStorage _blobInventoryStorage;
    private readonly ICaughtBlobStorage _caughtBlobStorage;

    public CatchBlobCommand(IEncounteredBlobStorage encounteredBlobStorage, Guid encounteredBlobId,
        IBlobInventoryStorage blobInventoryStorage, ICaughtBlobStorage caughtBlobStorage)
    {
        encounteredBlobStorage.ThrowIfNull(nameof(encounteredBlobStorage));
        encounteredBlobId.ThrowIfNull(nameof(encounteredBlobId));
        blobInventoryStorage.ThrowIfNull(nameof(blobInventoryStorage));
        caughtBlobStorage.ThrowIfNull(nameof(caughtBlobStorage));

        _encounteredBlobStorage = encounteredBlobStorage;
        _encounteredBlobId = encounteredBlobId;
        _blobInventoryStorage = blobInventoryStorage;
        _caughtBlobStorage = caughtBlobStorage;
    }

    public void Execute()
    {
        var encounteredBlob = _encounteredBlobStorage.GetBlob(_encounteredBlobId);
        var blob = new CaughtBlobModel(encounteredBlob.Name, encounteredBlob.Health);

        var inventory = _blobInventoryStorage.GetInventory();
        inventory.AddBlob(blob.Id);

        _caughtBlobStorage.AddBlob(blob);
    }
}
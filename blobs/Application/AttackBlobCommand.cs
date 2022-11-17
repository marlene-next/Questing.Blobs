namespace blobs.Application;

public class AttackBlobCommand
{
    private readonly IEncounteredBlobStorage _storage;
    private readonly Guid _blobId;
    
    public AttackBlobCommand(IEncounteredBlobStorage storage, Guid blobId)
    {
        storage.ThrowIfNull(nameof(storage));
        blobId.ThrowIfNull(nameof(blobId));

        _storage = storage;
        _blobId = blobId;
    }
    
    public void Execute()
    {
        var attackingBlobStrength = 10;
        var blob =_storage.GetBlob(_blobId);
        blob.DecreaseHealth(attackingBlobStrength);
    }
}
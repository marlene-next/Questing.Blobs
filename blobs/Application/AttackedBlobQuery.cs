namespace blobs.Application;

public class AttackedBlobQuery : IQuery<BlobViewModel>
{
    private readonly IEncounteredBlobStorage _storage;
    private readonly Guid _blobId;

    public AttackedBlobQuery(IEncounteredBlobStorage storage, Guid blobId)
    {
        storage.ThrowIfNull(nameof(storage));
        blobId.ThrowIfNull(nameof(blobId));

        _storage = storage;
        _blobId = blobId;
    }

    public BlobViewModel Run()
    {
        var blob = _storage.GetBlob(_blobId);

        return new BlobViewModel(blob.Id, blob.Name, blob.Health);
    }
}
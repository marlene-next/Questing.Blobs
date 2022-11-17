namespace blobs.Application;

public class DiscoveredBlobQuery
{
    private readonly IEncounteredBlobStorage _storage;

    public DiscoveredBlobQuery(IEncounteredBlobStorage storage)
    {
        storage.ThrowIfNull(nameof(storage));

        _storage = storage;
    }

    public BlobViewModel Run()
    {
        var blob = _storage.GetEncounteredBlob();

        return new BlobViewModel(blob.Id, blob.Name, blob.Health);
    }
}
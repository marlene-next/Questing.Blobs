namespace blobs.Application;

public class FoundBlobQuery
{
    private readonly IEncounteredBlobStorage _storage;
    
    public FoundBlobQuery(IEncounteredBlobStorage storage)
    {
        storage.ThrowIfNull(nameof(storage));

        _storage = storage;
    }
    
    public BlobViewModel Run()
    {
        var blob = _storage.GetBlob();

        return new BlobViewModel(blob.Name, blob.Health);
    }
}
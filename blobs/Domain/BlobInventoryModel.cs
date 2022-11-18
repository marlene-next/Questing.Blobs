namespace blobs.Domain;

public class BlobInventoryModel
{
    private readonly List<Guid> _blobIds = new();

    public void AddBlob(Guid blobId)
    {
        _blobIds.Add(blobId);
    }

    public IEnumerable<Guid> GetBlobIds()
    {
        return _blobIds;
    }
}
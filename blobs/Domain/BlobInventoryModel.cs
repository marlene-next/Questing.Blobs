namespace blobs.Domain;

public class BlobInventoryModel
{
    private readonly List<Guid> _ownedBlobIds = new();

    public void AddCaughtBlob(CaughtBlobModel blob)
    {
        _ownedBlobIds.Add(blob.Id);
    }

    public IEnumerable<Guid> GetOwnedBlobIds()
    {
        return _ownedBlobIds;
    }
}
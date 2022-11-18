using blobs.Application;
using blobs.Domain;

namespace blobs.Infrastructure;

public class BlobInventoryStorage : IBlobInventoryStorage
{
    private BlobInventoryModel _inventory;

    public BlobInventoryStorage()
    {
        _inventory = new BlobInventoryModel();
    }

    public BlobInventoryModel GetInventory()
    {
        return _inventory;
    }
}
using blobs.Domain;

namespace blobs.Application;

public interface IBlobInventoryStorage
{
    BlobInventoryModel GetInventory();
}
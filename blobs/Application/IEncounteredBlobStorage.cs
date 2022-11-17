using blobs.Domain;

namespace blobs.Application;

public interface IEncounteredBlobStorage
{
    EncounteredBlobModel GetEncounteredBlob();
    EncounteredBlobModel GetBlob(Guid id);
    void AddBlob(EncounteredBlobModel blob);
}
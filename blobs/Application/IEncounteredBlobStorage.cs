using blobs.Domain;

namespace blobs.Application;

public interface IEncounteredBlobStorage
{
    EncounteredBlobModel GetBlob();
    void AddBlob(EncounteredBlobModel blob);
}
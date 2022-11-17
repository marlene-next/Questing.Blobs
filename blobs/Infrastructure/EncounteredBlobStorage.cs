using blobs.Application;
using blobs.Domain;

namespace blobs.Infrastructure;

public class EncounteredBlobStorage : IEncounteredBlobStorage
{
    private EncounteredBlobModel _blob;

    public EncounteredBlobModel GetEncounteredBlob()
    {
        return _blob;
    }

    public EncounteredBlobModel GetBlob(Guid id)
    {
        return GetEncounteredBlob();
    }

    public void AddBlob(EncounteredBlobModel blob)
    {
        blob.ThrowIfNull(nameof(blob));

        _blob = blob;
    }
}
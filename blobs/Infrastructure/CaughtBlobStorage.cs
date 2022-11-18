using blobs.Application;
using blobs.Domain;

namespace blobs.Infrastructure;

public class CaughtBlobStorage : ICaughtBlobStorage
{
    private readonly List<CaughtBlobModel> _blobModels = new();

    public void AddBlob(CaughtBlobModel blob)
    {
        blob.ThrowIfNull(nameof(blob));

        _blobModels.Add(blob);
    }

    public IEnumerable<CaughtBlobModel> GetBlobModels(IEnumerable<Guid> ids)
    {
        return _blobModels.Where(blobModel => ids.Contains(blobModel.Id));
    }
}
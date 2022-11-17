using blobs.Domain;

namespace blobs.Application;

public class DiscoverBlobCommand
{
    private readonly IEncounteredBlobStorage _storage;

    public DiscoverBlobCommand(IEncounteredBlobStorage storage)
    {
        storage.ThrowIfNull(nameof(storage));

        _storage = storage;
    }

    public void Execute()
    {
        var blob = new EncounteredBlobModel("Grogo", 100);

        _storage.AddBlob(blob);
    }
}
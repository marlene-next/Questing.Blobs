using blobs.Domain;

namespace blobs.Application;

public class FindBlobCommand
{
    private readonly IEncounteredBlobStorage _storage;
    
    public FindBlobCommand(IEncounteredBlobStorage storage)
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
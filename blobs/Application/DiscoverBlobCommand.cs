using blobs.Domain;

namespace blobs.Application;

public class DiscoverBlobCommand
{
    private readonly IEncounteredBlobStorage _storage;
    private readonly IBlobDefinitionProvider _blobDefinitionProvider;

    public DiscoverBlobCommand(IEncounteredBlobStorage storage, IBlobDefinitionProvider blobDefinitionProvider)
    {
        storage.ThrowIfNull(nameof(storage));
        blobDefinitionProvider.ThrowIfNull(nameof(blobDefinitionProvider));

        _storage = storage;
        _blobDefinitionProvider = blobDefinitionProvider;
    }

    public void Execute()
    {
        var definition = _blobDefinitionProvider.GetRandomBlobDefinition();
        var blob = new EncounteredBlobModel(definition.Name, definition.Health);

        _storage.AddBlob(blob);
    }
}
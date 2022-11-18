using blobs.Application.Definitions;

namespace blobs.Application;

public interface IBlobDefinitionProvider
{
    BlobDefinition GetRandomBlobDefinition();
}
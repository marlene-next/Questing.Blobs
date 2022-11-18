using blobs.Application;
using blobs.Application.Definitions;

namespace blobs.Infrastructure;

public class BlobDefinitionProvider : IBlobDefinitionProvider
{
    private readonly IReadOnlyList<BlobDefinition> _definitions;
    private readonly Random _random;

    public BlobDefinitionProvider()
    {
        _random = new Random(DateTime.Now.Millisecond);
        _definitions = new List<BlobDefinition>
        {
            new("Grogo", 100),
            new("Plumpi", 50),
            new("Kotti", 70),
            new("Palo", 30)
        };
    }

    public BlobDefinition GetRandomBlobDefinition()
    {
        var randomIndex = _random.Next(0, _definitions.Count);
        return _definitions[randomIndex];
    }
}
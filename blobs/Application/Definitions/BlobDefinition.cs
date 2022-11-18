namespace blobs.Application.Definitions;

public class BlobDefinition
{
    public string Name { get; }
    public int Health { get; }

    public BlobDefinition(string name, int health)
    {
        Name = name;
        Health = health;
    }
}
namespace blobs.Domain;

public class EncounteredBlobModel
{
    public readonly string Name;
    public int Health;
    
    public EncounteredBlobModel(string name, int health)
    {
        name.ThrowIfNull(nameof(name));

        Name = name;
        Health = health;
    }
}
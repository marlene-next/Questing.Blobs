namespace blobs.Domain;

public class CaughtBlobModel
{
    public Guid Id { get; }
    public string Name { get; }
    public int Health { get; }

    public CaughtBlobModel(string name, int health)
    {
        name.ThrowIfNull(nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        Health = health;
    }
}
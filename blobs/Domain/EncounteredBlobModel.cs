namespace blobs.Domain;

public class EncounteredBlobModel
{
    public Guid Id { get; }
    public string Name { get; }
    public int Health { get; private set; }

    public EncounteredBlobModel(string name, int health)
    {
        name.ThrowIfNull(nameof(name));

        Id = Guid.NewGuid();
        Name = name;
        Health = health;
    }

    public void DecreaseHealth(int amount)
    {
        Health -= amount;
    }
}
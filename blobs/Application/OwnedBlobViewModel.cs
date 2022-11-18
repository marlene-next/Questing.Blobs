namespace blobs.Application;

public class OwnedBlobViewModel : IViewModel
{
    public Guid Id { get; }
    public string Name { get; }
    public int Health { get; }

    public OwnedBlobViewModel(Guid id, string name, int health)
    {
        id.ThrowIfNull(nameof(id));
        name.ThrowIfNull(nameof(name));
        health.ThrowIfNull(nameof(health));

        Id = id;
        Name = name;
        Health = health;
    }

    public override string ToString()
    {
        return $"{Name}:{Environment.NewLine}HP {Health}{Environment.NewLine}";
    }
}
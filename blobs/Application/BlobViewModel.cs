namespace blobs.Application;

public class BlobViewModel : IViewModel
{
    public Guid Id { get; }
    public string Name { get; }
    public int Health { get; }

    public BlobViewModel(Guid id, string name, int health)
    {
        id.ThrowIfNull(nameof(id));
        name.ThrowIfNull(nameof(name));
        health.ThrowIfNull(nameof(health));

        Id = id;
        Name = name;
        Health = health;
    }
}
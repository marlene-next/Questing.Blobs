namespace blobs.Application;

public class BlobViewModel : IViewModel
{
    public string Name { get; }
    public int Health { get; }

    public BlobViewModel(string name, int health)
    {
        name.ThrowIfNull(nameof(name));
        health.ThrowIfNull(nameof(health));
        
        Name = name;
        Health = health;
    }
}
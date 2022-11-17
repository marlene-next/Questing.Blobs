namespace blobs.Application;

public class BlobViewModel : IViewModel
{
    public string Name { get; }

    public BlobViewModel(string name)
    {
        Name = name;
    }
}
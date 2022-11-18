using blobs.Application;

namespace blobs.Presentation.Views;

public class ExplorationView : IView
{
    public void ShowBlobFound(BlobViewModel blob)
    {
        Console.WriteLine($"Found blob: {blob.Name}");
    }
}
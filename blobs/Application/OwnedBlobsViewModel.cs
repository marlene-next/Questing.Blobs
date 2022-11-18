namespace blobs.Application;

public class OwnedBlobsViewModel : IViewModel
{
    public IEnumerable<OwnedBlobViewModel> OwnedBlobs { get; }

    public OwnedBlobsViewModel(IEnumerable<OwnedBlobViewModel> ownedBlobs)
    {
        ownedBlobs.ThrowIfNull(nameof(ownedBlobs));

        OwnedBlobs = ownedBlobs;
    }
}
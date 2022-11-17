using blobs.Application;

namespace blobs.Presentation.States;

public interface IPresenter
{
    void Initialize(IViewModel viewModel);
    void Present();
}
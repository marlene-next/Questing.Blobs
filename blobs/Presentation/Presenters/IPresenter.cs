using blobs.Application;

namespace blobs.Presentation.Presenters;

public interface IPresenter
{
    void Initialize(IViewModel viewModel);
    void Present();
}
using blobs.Application;

namespace blobs.Presentation.States;

public interface IStateMachine
{
    void ChangeState(string state, IViewModel viewModel);
    void Close();
}
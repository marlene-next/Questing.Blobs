using blobs.Application;

namespace blobs.Presentation.States;

public interface IStateMachine
{
    void ChangeState(string stateName, IViewModel viewModel = null);
    void Close();
}
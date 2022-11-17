namespace blobs.Presentation.States;

public interface IStateMachine
{
    void ChangeState(string state);
    void Close();
}
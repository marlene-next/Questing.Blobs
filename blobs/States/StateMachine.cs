namespace blobs.States;

public class StateMachine
{
    private readonly Dictionary<string, IPresenter> _states;
    private readonly string _initialState;

    public StateMachine(Dictionary<string, IPresenter> states, string initialState)
    {
        _states = states;
        _initialState = initialState;
    }

    public void Start()
    {
        Console.WriteLine("Start");
        ChangeState(_initialState);
    }

    private void ChangeState(string state)
    {
        _states[state].Present();
    }
}
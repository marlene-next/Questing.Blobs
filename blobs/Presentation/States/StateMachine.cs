using blobs.Application;

namespace blobs.Presentation.States;

public class StateMachine : IStateMachine
{
    private Dictionary<string, IPresenter> _states = new();
    private string _initialState = string.Empty;

    public void Initialize(Dictionary<string, IPresenter> states, string initialState)
    {
        states.ThrowIfNull(nameof(states));
        initialState.ThrowIfNull(nameof(initialState));

        _states = states;
        _initialState = initialState;
    }

    public void Start()
    {
        Console.WriteLine("Start");
        ChangeState(_initialState);
    }

    public void ChangeState(string state, IViewModel viewModel = null)
    {
        _states[state].Initialize(viewModel);
        _states[state].Present();
    }

    public void Close()
    {
        Console.WriteLine("Close");
    }
}
using blobs.States;

var stateMachine = new StateMachine();
var states = new Dictionary<string, IPresenter>
{
    { "MainMenu", new MainMenuPresenter(stateMachine) }
};
stateMachine.Initialize(states, "MainMenu");

stateMachine.Start();
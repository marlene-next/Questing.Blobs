using blobs.States;

var states = new Dictionary<string, IPresenter>
{
    { "MainMenu", new MainMenuPresenter() }
};
var stateMachine = new StateMachine(states, "MainMenu");

stateMachine.Start();
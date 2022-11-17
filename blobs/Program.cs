using blobs.Presentation.States;

var stateMachine = new StateMachine();
var states = new Dictionary<string, IPresenter>
{
    { StateNameConstants.MainMenuState, new MainMenuPresenter(stateMachine) },
    { StateNameConstants.BlobdexState, new BlobdexPresenter(stateMachine) },
    { StateNameConstants.EncounterState, new EncounterPresenter(stateMachine) },
    { StateNameConstants.FightResultsState, new FightResultsPresenter(stateMachine) }
};

stateMachine.Initialize(states, StateNameConstants.MainMenuState);
stateMachine.Start();
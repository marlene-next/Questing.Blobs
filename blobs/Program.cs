using blobs.Infrastructure;
using blobs.Presentation.States;

var encounteredBlobStorage = new EncounteredBlobStorage();
var blobDefinitionProvider = new BlobDefinitionProvider();
var blobInventoryStorage = new BlobInventoryStorage();
var caughtBlobStorage = new CaughtBlobStorage();

var stateMachine = new StateMachine();
var states = new Dictionary<string, IPresenter>
{
    { StateNameConstants.MainMenuState, new MainMenuPresenter(stateMachine) },
    { StateNameConstants.BlobdexState, new BlobdexPresenter(stateMachine) },
    { StateNameConstants.ExplorationState, new ExplorationPresenter(stateMachine, encounteredBlobStorage, blobDefinitionProvider) },
    { StateNameConstants.EncounterState, new EncounterPresenter(stateMachine, encounteredBlobStorage, blobInventoryStorage, caughtBlobStorage) },
    { StateNameConstants.FightResultsState, new FightResultsPresenter(stateMachine) },
    { StateNameConstants.CatchResultsState, new CatchResultsPresenter(stateMachine) },
    { StateNameConstants.FleeResultsState, new FleeResultsPresenter(stateMachine) }
};

stateMachine.Initialize(states, StateNameConstants.MainMenuState);
stateMachine.Start();
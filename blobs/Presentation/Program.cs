using blobs.Infrastructure;
using blobs.Presentation.Presenters;
using blobs.Presentation.States;
using blobs.Presentation.Views;

var encounteredBlobStorage = new EncounteredBlobStorage();
var blobDefinitionProvider = new BlobDefinitionProvider();
var blobInventoryStorage = new BlobInventoryStorage();
var caughtBlobStorage = new CaughtBlobStorage();

var explorationView = new ExplorationView();
var stubView = new StubView();

var stateMachine = new StateMachine();
var states = new Dictionary<string, IPresenter>
{
    { StateNameConstants.MainMenuState, new MainMenuPresenter(stateMachine, stubView) },
    { StateNameConstants.BlobdexState, new BlobdexPresenter(stateMachine, stubView, blobInventoryStorage, caughtBlobStorage) },
    { StateNameConstants.ExplorationState, new ExplorationPresenter(stateMachine, explorationView, encounteredBlobStorage, blobDefinitionProvider) },
    { StateNameConstants.EncounterState, new EncounterPresenter(stateMachine, stubView, encounteredBlobStorage, blobInventoryStorage, caughtBlobStorage) },
    { StateNameConstants.FightResultsState, new FightResultsPresenter(stateMachine, stubView) },
    { StateNameConstants.CatchResultsState, new CatchResultsPresenter(stateMachine, stubView) },
    { StateNameConstants.FleeResultsState, new FleeResultsPresenter(stateMachine, stubView) }
};

stateMachine.Initialize(states, StateNameConstants.MainMenuState);

Console.WriteLine($"{Environment.NewLine}Welcome to Blobland!{Environment.NewLine}");

stateMachine.Start();
﻿using blobs.Infrastructure;
using blobs.Presentation.States;

var encounteredBlobStorage = new EncounteredBlobStorage();

var stateMachine = new StateMachine();
var states = new Dictionary<string, IPresenter>
{
    { StateNameConstants.MainMenuState, new MainMenuPresenter(stateMachine) },
    { StateNameConstants.BlobdexState, new BlobdexPresenter(stateMachine) },
    { StateNameConstants.ExplorationState, new ExplorationPresenter(encounteredBlobStorage, stateMachine) },
    { StateNameConstants.EncounterState, new EncounterPresenter(stateMachine) },
    { StateNameConstants.FightResultsState, new FightResultsPresenter(stateMachine) },
    { StateNameConstants.CatchResultsState, new CatchResultsPresenter(stateMachine) },
    { StateNameConstants.FleeResultsState, new FleeResultsPresenter(stateMachine) }
};

stateMachine.Initialize(states, StateNameConstants.MainMenuState);
stateMachine.Start();
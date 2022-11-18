﻿using blobs.Application;

namespace blobs.Presentation.States;

public class EncounterPresenter : PresenterBase
{
    private readonly IEncounteredBlobStorage _encounteredBlobStorage;
    private BlobViewModel _blob;
    private InputHandler _inputHandler;
    private readonly IBlobInventoryStorage _blobInventoryStorage;
    private readonly ICaughtBlobStorage _caughtBlobStorage;

    public EncounterPresenter(IStateMachine stateMachine, IEncounteredBlobStorage encounteredBlobStorage,
        IBlobInventoryStorage blobInventoryStorage, ICaughtBlobStorage caughtBlobStorage) : base(stateMachine)
    {
        encounteredBlobStorage.ThrowIfNull(nameof(encounteredBlobStorage));
        blobInventoryStorage.ThrowIfNull(nameof(blobInventoryStorage));
        caughtBlobStorage.ThrowIfNull(nameof(caughtBlobStorage));

        _encounteredBlobStorage = encounteredBlobStorage;
        _blobInventoryStorage = blobInventoryStorage;
        _caughtBlobStorage = caughtBlobStorage;
    }

    public override void Initialize(IViewModel viewModel)
    {
        viewModel.ThrowIfNull(nameof(viewModel));
        _blob = (BlobViewModel) viewModel;

        _inputHandler = InputHandler.Create()
            .Add(ConsoleKey.A, "attack")
            .Add(ConsoleKey.C, "catch")
            .Add(ConsoleKey.F, "flee");
    }

    public override void Present()
    {
        Console.WriteLine($"{_blob.Name}");

        switch (_inputHandler.WaitForKey())
        {
            case ConsoleKey.A:
                var previousHealth = _blob.Health;

                var attackBlobCommand = new AttackBlobCommand(_encounteredBlobStorage, _blob.Id);
                attackBlobCommand.Execute();

                var attackedBlobQuery = new AttackedBlobQuery(_encounteredBlobStorage, _blob.Id);
                _blob = attackedBlobQuery.Run();

                Console.WriteLine($"{_blob.Name}: {_blob.Health} HP (-{previousHealth - _blob.Health})");

                if (_blob.Health > 0)
                {
                    Present();
                    return;
                }

                StateMachine.ChangeState(StateNameConstants.FightResultsState);
                break;
            case ConsoleKey.C:
                var catchBlobCommand = new CatchBlobCommand(_encounteredBlobStorage, _blob.Id, _blobInventoryStorage,
                    _caughtBlobStorage);
                catchBlobCommand.Execute();

                StateMachine.ChangeState(StateNameConstants.CatchResultsState, _blob);
                break;
            case ConsoleKey.F:
                StateMachine.ChangeState(StateNameConstants.FleeResultsState);
                break;
        }
    }
}
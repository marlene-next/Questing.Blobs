using blobs.Application;

namespace blobs.Presentation.States;

public abstract class PresenterBase : IPresenter
{
    protected readonly IStateMachine StateMachine;

    protected PresenterBase(IStateMachine stateMachine)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));

        StateMachine = stateMachine;
    }

    public abstract void Initialize(IViewModel viewModel);

    public abstract void Present();
}
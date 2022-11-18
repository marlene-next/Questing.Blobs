using blobs.Application;
using blobs.Presentation.Views;

namespace blobs.Presentation.States;

public abstract class PresenterBase<T> : IPresenter where T : IView
{
    protected readonly IStateMachine StateMachine;
    protected readonly T View;

    protected PresenterBase(IStateMachine stateMachine, T view)
    {
        stateMachine.ThrowIfNull(nameof(stateMachine));
        view.ThrowIfNull(nameof(view));

        StateMachine = stateMachine;
        View = view;
    }

    public abstract void Initialize(IViewModel viewModel);

    public abstract void Present();
}
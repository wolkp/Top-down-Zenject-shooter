using Zenject;

public abstract class CharacterAction
{
    protected abstract bool CanExecute(IActionContext context);

    protected abstract void OnExecute(SignalBus signalBus, IActionContext context);

    public virtual void Execute(SignalBus signalBus, IActionContext context)
    {
        if (!CanExecute(context)) 
            return;

        OnExecute(signalBus, context);
    }
}
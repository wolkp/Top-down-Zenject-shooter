using UnityEngine;
using Zenject;

public class JumpAction : CharacterAction
{
    protected override void OnExecute(SignalBus signalBus, IActionContext context)
    {
        if(context is JumpActionContext jumpActionContext)
        {
            signalBus.Fire(new JumpSignal(jumpActionContext));
        }
        else
        {
            Debug.LogError("JumpAction requires JumpActionContext!");
        }
    }

    protected override bool CanExecute(IActionContext context)
    {
        if (context is not JumpActionContext jumpActionContext)
            return false;

        if (jumpActionContext.Movable is not MovableEntity movable)
            return false;

        return movable.IsGrounded;
    }
}

public class JumpActionContext : IActionContext
{
    public IMovable Movable { get; }

    public JumpActionContext(IMovable movable)
    {
        Movable = movable;
    }
}
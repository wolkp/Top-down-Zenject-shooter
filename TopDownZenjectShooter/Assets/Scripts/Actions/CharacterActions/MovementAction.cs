using UnityEngine;
using Zenject;

public class MovementAction : CharacterAction
{
    protected override void OnExecute(SignalBus signalBus, IActionContext context)
    {
        if (context is MovementActionContext movementActionContext)
        {
            signalBus.Fire(new MoveSignal(movementActionContext));
        }
        else
        {
            Debug.LogError("MovementAction requires MovementActionContext!");
        }
    }

    protected override bool CanExecute(IActionContext context)
    {
        var result = true;

        if (context is MovementActionContext movementActionContext)
        {
            var movable = movementActionContext.Movable;

            if (movable != null && movable is MovableEntity movableEntity)
            {
                if (!movableEntity.CanMoveInDirection(movementActionContext.MovementDirection))
                    result = false;
            }
        }
        else
        {
            result = false;
        }

        return result;
    }
}

public class MovementActionContext : IActionContext
{
    public IMovable Movable { get; }
    public Vector3 MovementDirection { get; }

    public MovementActionContext(IMovable movable, Vector3 movementDirection)
    {
        Movable = movable;
        MovementDirection = movementDirection;
    }
}
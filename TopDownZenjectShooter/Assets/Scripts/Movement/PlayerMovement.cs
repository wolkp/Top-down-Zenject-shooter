using UnityEngine;
using Zenject;

public class PlayerMovement : MovableEntity
{
    protected override Vector3 MovementDirection => _inputMovementDirection;

    private bool HasMovementInput => _inputMovementDirection.sqrMagnitude > 0;

    private SignalBus _signalBus;
    private Vector3 _inputMovementDirection;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;

        _signalBus.Subscribe<MoveSignal>(OnMoveSignal);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<MoveSignal>(OnMoveSignal);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (IsRigidbodyMoving())
            _signalBus.Fire(new PlayerRigidbodyMoveSignal(this));
    }

    protected override bool CanMove()
    {
        return HasMovementInput;
    }

    private bool IsRigidbodyMoving()
    {
        return movedRigidbody != null && movedRigidbody.velocity.sqrMagnitude > 0;
    }

    private void OnMoveSignal(MoveSignal signal)
    {
        if (signal.Context.Movable != (IMovable)this)
            return;

        var localMovementDirection = signal.Context.MovementDirection;
        var worldSpaceMovementDirection = MovedTransform.TransformDirection(localMovementDirection);

        _inputMovementDirection = worldSpaceMovementDirection;
    }
}

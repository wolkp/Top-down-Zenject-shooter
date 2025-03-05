using UnityEngine;

[CreateAssetMenu(menuName = "States/MovementInputCharacterState")]
public class MovementInputCharacterState : InputCharacterState
{
    public override bool HasInput(KeyCode inputKey)
    {
        var inputConfig = config as MovementInputCharacterStateConfig;

        return  inputConfig.InputForward == inputKey  ||
                inputConfig.InputBackward == inputKey ||
                inputConfig.InputLeft == inputKey     ||
                inputConfig.InputRight == inputKey;
    }

    public override void OnInputReceived(CharacterStateController stateController, KeyCode inputKey)
    {
        base.OnInputReceived(stateController, inputKey);

        var movementDirection = GetMovementDirection(inputKey);
        ExecuteMovementAction(stateController, movementDirection);
    }

    public override void StateExit(CharacterStateController stateController)
    {
        base.StateExit(stateController);

        ExecuteMovementAction(stateController, Vector3.zero); // clears movement direction on exit
    }

    private void ExecuteMovementAction(CharacterStateController stateController, Vector3 movementDirection)
    {
        var movementContext = new MovementActionContext(stateController.Movable, movementDirection);
        var movementAction = new MovementAction();

        movementAction.Execute(signalBus, movementContext);
    }

    private Vector3 GetMovementDirection(KeyCode inputKey)
    {
        var inputConfig = config as MovementInputCharacterStateConfig;
        var direction = Vector3.zero;

        if (inputConfig.InputForward == inputKey)  direction += Vector3.forward;
        if (inputConfig.InputBackward == inputKey) direction += Vector3.back;
        if (inputConfig.InputLeft == inputKey)     direction += Vector3.left;
        if (inputConfig.InputRight == inputKey)    direction += Vector3.right;

        return direction.normalized;
    }
}
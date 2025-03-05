using UnityEngine;

[CreateAssetMenu(menuName = "States/JumpCharacterState")]
public class JumpCharacterState : SingleInputCharacterState
{
    protected override void ExecuteInputAction(CharacterStateController stateController)
    {
        var jumpContext = new JumpActionContext(stateController.Movable);
        var jumpAction = new JumpAction();

        jumpAction.Execute(signalBus, jumpContext);
    }
}
using UnityEngine;

public abstract class SingleInputCharacterState : InputCharacterState
{
    protected abstract void ExecuteInputAction(CharacterStateController stateController);

    public override bool HasInput(KeyCode inputKey)
    {
        var inputConfig = config as SingleInputCharacterStateConfig;
        var stateKey = inputConfig.InputKey;
        return stateKey == inputKey;
    }

    public override void StateEnter(CharacterStateController stateController)
    {
        base.StateEnter(stateController);

        ExecuteInputAction(stateController);
    }
}
using UnityEngine;

public abstract class InputCharacterState : CharacterState
{
    public abstract bool HasInput(KeyCode inputKey);

    public virtual void OnInputReceived(CharacterStateController stateController, KeyCode inputKey)
    {
    }
}
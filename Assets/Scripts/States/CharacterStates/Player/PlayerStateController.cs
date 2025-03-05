using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateController : CharacterStateController
{
    protected override void OnAfterConstruct()
    {
        base.OnAfterConstruct();
        signalBus.Subscribe<KeyboardMouseInputSignal>(OnInputReceived);
        signalBus.Subscribe<KeyboardMouseInputReleasedSignal>(OnInputReleased);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        signalBus.Unsubscribe<KeyboardMouseInputSignal>(OnInputReceived);
        signalBus.Unsubscribe<KeyboardMouseInputReleasedSignal>(OnInputReleased);
    }

    private void OnInputReceived(KeyboardMouseInputSignal signal)
    {
        var correspondingState = GetStateByInput(signal.KeyCode);
        if(correspondingState != default)
        {
            correspondingState.OnInputReceived(this, signal.KeyCode);
            ChangeState(correspondingState);
        }
    }

    private void OnInputReleased(KeyboardMouseInputReleasedSignal signal)
    {
        var correspondingState = GetStateByInput(signal.KeyCode);
        if (correspondingState == currentState)
        {
            ClearCurrentState();
        }
    }

    private InputCharacterState GetStateByInput(KeyCode inputKey)
    {
        foreach(var state in statesRegistry.GetAllItems())
        {
            if(state is InputCharacterState inputState && inputState.HasInput(inputKey))
            {
                return inputState;
            }
        }

        return default;
    }
}
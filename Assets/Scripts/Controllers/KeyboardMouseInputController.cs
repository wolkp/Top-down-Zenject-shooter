using System;
using UnityEngine;
using Zenject;

public class KeyboardMouseInputController : IInputController
{
    private readonly SignalBus _signalBus;
    private readonly KeyCode[] _keyCodes;

    [Inject]
    public KeyboardMouseInputController(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _keyCodes = Enum.GetValues(typeof(KeyCode)) as KeyCode[];
    }

    public void UpdateInput()
    {
        foreach(var keyCode in _keyCodes)
        {
            if (Input.GetKey(keyCode))
            {
                _signalBus.Fire(new KeyboardMouseInputSignal(keyCode));
            }
            else if (Input.GetKeyUp(keyCode))
            {
                _signalBus.Fire(new KeyboardMouseInputReleasedSignal(keyCode));
            }
        }

        UpdateMousePosition();
    }

    private void UpdateMousePosition()
    {
        var mousePosition = Input.mousePosition;
        _signalBus.Fire(new MousePositionSignal(mousePosition));
    }
}
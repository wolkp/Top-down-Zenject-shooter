using UnityEngine;

public class KeyboardMouseInputReleasedSignal : InputSignal
{
    public KeyCode KeyCode { get; private set; }

    public KeyboardMouseInputReleasedSignal(KeyCode keyCode)
    {
        KeyCode = keyCode;
    }
}
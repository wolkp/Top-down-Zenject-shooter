using UnityEngine;

public class KeyboardMouseInputSignal : InputSignal
{
    public KeyCode KeyCode { get; private set; }

    public KeyboardMouseInputSignal(KeyCode keyCode)
    {
        KeyCode = keyCode;
    }
}
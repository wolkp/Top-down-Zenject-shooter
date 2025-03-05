using UnityEngine;

public class MousePositionSignal : ISignal
{
    public Vector3 ScreenPosition { get; private set; }

    public MousePositionSignal(Vector3 screenPosition)
    {
        ScreenPosition = screenPosition;
    }
}
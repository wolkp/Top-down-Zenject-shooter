using UnityEngine;

[CreateAssetMenu(menuName = "Configs/State/MovementInputCharacterStateConfig")]
public class MovementInputCharacterStateConfig : InputCharacterStateConfig
{
    public KeyCode InputForward;
    public KeyCode InputBackward;
    public KeyCode InputLeft;
    public KeyCode InputRight;
}
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/MovementConfig")]
public class MovementConfig : ScriptableObject
{
    public float Speed = 5f;
    public bool RequireFloorForMovement = true;
}
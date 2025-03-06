using UnityEngine;

[CreateAssetMenu(menuName = "Configs/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    public KeyCode InputKey;
    public ProjectileBase ProjectilePrefab;
    public float ShootInterval = 0.5f;
}
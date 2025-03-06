using UnityEngine;

public class SingleTargetProjectile : ProjectileBase
{
    [SerializeField] private ProjectileConfig _projectileConfig;

    protected override void TriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<IDamageable>(out var damageable))
        {
            DealDamage(damageable, _projectileConfig.Damage);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class AreaTargetProjectile : ProjectileBase
{
    [SerializeField] private AreaProjectileConfig _projectileConfig;

    protected override void TriggerEnter(Collider other)
    {
        var hits = Physics.SphereCastAll(MovedTransform.position, _projectileConfig.Radius, MovedTransform.forward);
        var alreadyCheckedDamagaebles= new List<IDamageable>();

        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent<IDamageable>(out var damageableComponent) &&
                !alreadyCheckedDamagaebles.Contains(damageableComponent))
            {
                DealDamage(damageableComponent, _projectileConfig.Damage);
                alreadyCheckedDamagaebles.Add(damageableComponent);
            }
        }
    }
}
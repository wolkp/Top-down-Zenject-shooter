using UnityEngine;

public abstract class ProjectileBase : MovableEntity, IProjectile
{
    protected override Vector3 MovementDirection => MovedTransform.forward;

    protected abstract void TriggerEnter(Collider other);

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter(other);
        Destroy(gameObject);
    }
        
    public void DealDamage(IDamageable damageable, int damage)
    {
        damageable.TakeDamage(damage);
    }

    protected override bool CanMove()
    {
        return true;
    }
}
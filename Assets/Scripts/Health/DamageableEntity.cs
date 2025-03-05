using UnityEngine;

public abstract class DamageableEntity : MonoBehaviour, IDamageable
{
    [SerializeField] private HealthConfig _healthConfig;

    protected int CurrentHealth { get; private set; }
    protected int MaxHealth => _healthConfig.Health;
    protected bool IsAlive => CurrentHealth > 0;

    protected abstract void OnDamageTaken(int damage);
    protected abstract void Die();

    protected virtual void Awake()
    {
        CurrentHealth = MaxHealth;
    }
     
    public void TakeDamage(int damage)
    {
        if (!IsAlive)
            return;

        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        OnDamageTaken(damage);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public float GetHealthPercentage()
    {
        return ((float)CurrentHealth / MaxHealth) * 100;
    }
}

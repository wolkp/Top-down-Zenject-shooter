using UnityEngine;
using Zenject;

public class EnemyHealth : DamageableEntity
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    protected override void OnDamageTaken(int damage)
    {
        _signalBus.Fire(new EnemyDamageTakenSignal(this, damage));
    }

    protected override void Die()
    {
        _signalBus.Fire(new EnemyDiedSignal(this));
    }
}
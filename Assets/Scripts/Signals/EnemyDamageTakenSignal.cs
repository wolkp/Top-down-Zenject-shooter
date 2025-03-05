public class EnemyDamageTakenSignal : ISignal
{
    public EnemyHealth EnemyHealth { get; private set; }
    public int Damage { get; private set; }

    public EnemyDamageTakenSignal(EnemyHealth enemyHealth, int damage)
    {
        EnemyHealth = enemyHealth;
        Damage = damage;
    }
}
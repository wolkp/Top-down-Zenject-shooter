public class EnemyDiedSignal : ISignal
{
    public EnemyHealth EnemyHealth { get; private set; }

    public EnemyDiedSignal(EnemyHealth enemyHealth)
    {
        EnemyHealth = enemyHealth;
    }
}
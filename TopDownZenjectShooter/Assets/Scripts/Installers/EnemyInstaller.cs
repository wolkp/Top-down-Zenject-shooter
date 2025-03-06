using Zenject;

public class EnemyInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMovable>().To<EnemyMovement>().FromComponentOn(gameObject).AsSingle();
        //Container.Bind<IRotatable>().To<EnemyRotation>().FromComponentOn(gameObject).AsSingle();
        Container.Bind<EnemyStateController>().FromComponentOn(gameObject).AsSingle();
    }
}
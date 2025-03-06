using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMovable>().To<PlayerMovement>().FromComponentOn(gameObject).AsSingle();
        Container.Bind<IRotatable>().To<PlayerRotation>().FromComponentOn(gameObject).AsSingle();
        Container.Bind<IMovementBehaviour>().To<JumpBehaviour>().FromComponentOn(gameObject).AsSingle();
        Container.Bind<PlayerStateController>().FromComponentOn(gameObject).AsSingle();
    }
}

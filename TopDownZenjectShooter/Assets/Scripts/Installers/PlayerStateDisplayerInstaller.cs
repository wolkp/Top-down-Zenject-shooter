using Zenject;

public class PlayerStateDisplayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerStateDisplayer>().FromComponentOn(gameObject).AsSingle();
    }
}
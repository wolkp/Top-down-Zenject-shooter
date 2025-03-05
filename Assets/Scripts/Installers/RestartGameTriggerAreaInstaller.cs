using Zenject;

public class RestartGameTriggerAreaInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<RestartGameTriggerArea>().FromComponentOn(gameObject).AsSingle();
    }
}
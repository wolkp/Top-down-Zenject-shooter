using Zenject;

public class EnemyHealthVisualizerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyHealthVisualizer>().FromComponentOnRoot().AsSingle();
        Container.Bind<EnemyHealth>().FromComponentOnRoot().AsSingle();
    }
}
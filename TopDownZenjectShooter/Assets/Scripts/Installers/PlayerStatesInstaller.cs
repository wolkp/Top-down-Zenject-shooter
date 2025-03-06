using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatesInstaller", menuName = "Installers/PlayerStatesInstaller")]
public class PlayerStatesInstaller : 
    CharacterStatesInstaller<PlayerStatesInitializer, PlayerStatesRegistry>
{
    public override void InstallBindings()
    {
        base.InstallBindings();

        Container.Bind<CharacterStatesRegistry>().To<PlayerStatesRegistry>().AsSingle();
    }
}
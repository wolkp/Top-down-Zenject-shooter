using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "GameSignalsInstaller", menuName = "Installers/GameSignalsInstaller")]
public class GameSignalsInstaller : ScriptableObjectInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        // Game lifecycle
        Container.DeclareSignal<RestartGameSignal>();
        Container.DeclareSignal<QuitGameSignal>();

        // Input 
        Container.DeclareSignal<KeyboardMouseInputSignal>();
        Container.DeclareSignal<KeyboardMouseInputReleasedSignal>();
        Container.DeclareSignal<MousePositionSignal>();

        // Character
        Container.DeclareSignal<CurrentCharacterStateChangedSignal>();
        Container.DeclareSignal<PlayerRigidbodyMoveSignal>();
        Container.DeclareSignal<MoveSignal>();
        Container.DeclareSignal<JumpSignal>();

        // Enemy
        Container.DeclareSignal<EnemyDamageTakenSignal>();
        Container.DeclareSignal<EnemyDiedSignal>();
    }
}
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "StateInstaller", menuName = "Installers/StateInstaller")]
public class CharacterStateInstaller : ScriptableObjectInstaller
{
    [SerializeField] private CharacterState _characterState;

    public CharacterState CharacterState => _characterState;

    public override void InstallBindings()
    {
        Container.QueueForInject(_characterState);

        Container.Bind<CharacterState>().FromInstance(_characterState).AsSingle();
    }
}
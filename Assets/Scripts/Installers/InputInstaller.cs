using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "InputInstaller", menuName = "Installers/InputInstaller")]
public class InputInstaller : ScriptableObjectInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputController>().To<KeyboardMouseInputController>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerInputController>().AsSingle();
    }
}
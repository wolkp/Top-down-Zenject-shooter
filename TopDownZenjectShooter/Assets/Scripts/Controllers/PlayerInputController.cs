using System.Collections.Generic;
using Zenject;

public class PlayerInputController : ITickable
{
    private readonly List<IInputController> _inputControllers;

    [Inject]
    public PlayerInputController(List<IInputController> inputControllers)
    {
        _inputControllers = inputControllers;
    }

    public void Tick()
    {
        foreach (var inputController in _inputControllers)
        {
            inputController.UpdateInput();
        }
    }
}
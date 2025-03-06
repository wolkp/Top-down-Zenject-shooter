using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class JumpBehaviour : MonoBehaviour, IMovementBehaviour
{
    [SerializeField] private float _jumpForce = 10f;

    private IMovable _movable;
    private SignalBus _signalBus;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    [Inject]
    public void Construct(SignalBus signalBus, IMovable movable)
    {
        _movable = movable;
        _signalBus = signalBus;

        _signalBus.Subscribe<JumpSignal>(OnJumpSignalReceived);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<JumpSignal>(OnJumpSignalReceived);
    }

    public void Execute()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    private void OnJumpSignalReceived(JumpSignal signal)
    {
        if (signal.Context.Movable != _movable)
            return;

        Execute();
    }
}
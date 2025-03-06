using UnityEngine;
using Zenject;

public class RestartGameTriggerArea : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null && 
            other.attachedRigidbody.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            _signalBus.Fire(new RestartGameSignal());
        }
    }
}
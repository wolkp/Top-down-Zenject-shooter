using TMPro;
using UnityEngine;
using Zenject;

public class PlayerStateDisplayer : MonoBehaviour
{
    [SerializeField] private string _message = "Player is";
    [SerializeField] private string _emptyStateName = "Idle";
    [SerializeField] private TMP_Text _stateText;

    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _signalBus.Subscribe<CurrentCharacterStateChangedSignal>(OnStateChanged);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<CurrentCharacterStateChangedSignal>(OnStateChanged);
    }

    private void OnStateChanged(CurrentCharacterStateChangedSignal signal)
    {
        if (signal.StateController is not PlayerStateController)
            return;

        var stateName = signal.NewState != null ? signal.NewState.StateName : _emptyStateName;

        _stateText.text = $"{_message} {stateName}";
    }
}
using UnityEngine.UI;
using Zenject;

public abstract class SignalButtonBase<TSignal> : Button
    where TSignal : ISignal, new()
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    protected override void Awake()
    {
        base.Awake();
        onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        var signal = new TSignal();
        _signalBus.Fire(signal);
    }
}
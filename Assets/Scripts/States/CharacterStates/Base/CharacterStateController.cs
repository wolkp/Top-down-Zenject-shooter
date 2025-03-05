using UnityEngine;
using Zenject;

public class CharacterStateController : MonoBehaviour
{
    public IMovable Movable => movable;

    protected IMovable movable;
    protected SignalBus signalBus;
    protected CharacterStatesRegistry statesRegistry;
    protected CharacterState currentState;

    [Inject]
    public virtual void Construct(SignalBus signalBus, IMovable movable, CharacterStatesRegistry statesRegistry)
    {
        this.signalBus = signalBus;
        this.movable = movable;
        this.statesRegistry = statesRegistry;

        OnAfterConstruct();
    }

    protected virtual void Update() 
    {
        UpdateCurrentState();
    }

    protected virtual void OnDestroy() { }

    protected virtual void OnAfterConstruct() { }

    protected void ChangeState(CharacterState newState)
    {
        if (currentState == newState)
            return;

        currentState?.StateExit(this);

        currentState = newState;

        currentState?.StateEnter(this);

        signalBus.Fire(new CurrentCharacterStateChangedSignal(this, newState));
    }

    protected void ClearCurrentState()
    {
        ChangeState(null);
    }

    private void UpdateCurrentState()
    {
        if (currentState == null)
            return;

        currentState.StateUpdate(this);
    }
}
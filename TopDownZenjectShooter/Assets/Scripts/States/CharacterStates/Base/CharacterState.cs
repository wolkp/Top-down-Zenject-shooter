using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "States/CharacterState")]
public class CharacterState : ScriptableObject
{
    [SerializeField] protected CharacterStateConfig config;

    public string StateName => config.StateName;

    [Inject] protected readonly SignalBus signalBus;

    public virtual void StateEnter(CharacterStateController stateController) { }

    public virtual void StateUpdate(CharacterStateController stateController) { }

    public virtual void StateExit(CharacterStateController stateController) { }

}
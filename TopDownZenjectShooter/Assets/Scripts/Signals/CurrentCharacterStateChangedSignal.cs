public class CurrentCharacterStateChangedSignal : ISignal
{
    public CharacterStateController StateController { get; private set; }
    public CharacterState NewState { get; private set; }

    public CurrentCharacterStateChangedSignal(CharacterStateController stateController, CharacterState newState)
    {
        StateController = stateController;
        NewState = newState;
    }
}
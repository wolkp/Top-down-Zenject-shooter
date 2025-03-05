public class PlayerRigidbodyMoveSignal : ISignal
{
    public PlayerMovement PlayerMovement { get; private set; }

    public PlayerRigidbodyMoveSignal(PlayerMovement movement)
    {
        PlayerMovement = movement;
    }
}
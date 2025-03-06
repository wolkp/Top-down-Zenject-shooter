public class MoveSignal : ISignal
{
    public MovementActionContext Context { get; private set; }

    public MoveSignal(MovementActionContext context)
    {
        Context = context;
    }
}
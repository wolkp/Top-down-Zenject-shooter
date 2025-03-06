public class JumpSignal : ISignal
{
    public JumpActionContext Context { get; private set; }

    public JumpSignal(JumpActionContext context)
    {
        Context = context;
    }
}
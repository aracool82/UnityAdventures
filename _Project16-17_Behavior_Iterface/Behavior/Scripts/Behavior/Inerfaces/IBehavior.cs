namespace _Project16_17.Scripts
{
    public interface IBehavior : IUpdateble
    {
        public bool IsEnabled { get; }
        public void DoAction();
    }
}
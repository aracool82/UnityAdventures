namespace _Project22_23.Scripts
{
    public interface IDamageble
    {
        public bool IsAlive { get; }
        public void TakeDamage(float amount);
    }
}
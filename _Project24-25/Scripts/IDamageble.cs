namespace _Project24_25.NavMesh2
{
    public interface IDamageble
    {
        public bool IsAlive { get; }
        public void TakeDamage(float amount);
    }
}
namespace _Project31.Scripts
{
    public interface IDamageble
    {
        void TakeDamage(float damage);
    }

    public interface IHeroDamageble : IDamageble
    {
    }
    
    public interface IEnemyDamageble : IDamageble
    {
    }
}
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public interface IExploded
    {
        public Rigidbody Rigidbody { get;}
        
        public void Initialize(Spawner spawner);
        public void Explode();
    }
}
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Dragon : Enemy
    {
         private int _health;
         private float _damage;

        public void Initialize(int health, float damage)
        {
            _damage = damage;
            _health = health;
        }
    }
}
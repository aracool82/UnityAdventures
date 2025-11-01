using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Ork : Enemy
    {
        private float _speed;
        private bool _isDead;

        public void Initialize(float speed, bool isDead)
        {
            _speed = speed;
            _isDead = isDead;
        }
    }
}
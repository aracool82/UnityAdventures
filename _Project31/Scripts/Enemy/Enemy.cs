using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project31.Scripts
{
    public class Enemy : MonoBehaviour, IEnemyDamageble
    {
        public event Action<Enemy> Dead;
        
        private Health _health;
        private Mover _mover;
        private float _damage;
        private float _timeToChangeDirection ;
        private float _time;
        private Vector3 _direction;
        
        public bool IsDead => _health.Current.Value <= 0;

        public void Initialize(Health health, Mover mover, float damage,float timeToChangeDirection)
        {
            _health = health;
            _mover = mover;
            _damage = damage;
            _timeToChangeDirection = timeToChangeDirection;
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _timeToChangeDirection)
            {
                _time = 0;
                _direction = GetRandomDirection();
            }

            _mover.SetDirection(_direction);
            _mover.Update(Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IHeroDamageble damageable))
                damageable.TakeDamage(_damage);
            
            _direction = -_direction;
            _time = 0;
        }

        private Vector3 GetRandomDirection()
            => new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        public void TakeDamage(float damage)
        {
            _health.Reduce(damage);

            if (_health.Current.Value <= 0)
                Dead?.Invoke(this);
        }
    }
}
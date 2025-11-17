using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project31.Scripts
{
    public class Enemy : MonoBehaviour, IDamageble
    {
        private Health _health;
        private Mover _mover;
        private float _damage;
        private float _timeToChangeDirection = 2;
        private float _time;
        private Vector3 _direction;

        [field: SerializeField] public float Health { get; private set; }

        private void Awake()
        {
            Initialize(new Health(100, 100), new Mover(transform, 2), 20);
        }

        public void Initialize(Health health, Mover mover, float damage)
        {
            _health = health;
            _damage = damage;
            _mover = mover;
            Health = health.Current.Value;
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _timeToChangeDirection)
            {
                _time = 0;
                _direction = GetDirection();
            }

            _mover.SetDirection(_direction);

            _mover.Update(Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out IDamageble damageable))
                damageable.TakeDamage(_damage);
            
            _direction = -_direction;
            _time = 0;
        }

        private Vector3 GetDirection()
            => new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        public void TakeDamage(float damage)
        {
            _health.Reduce(damage);
            Health = _health.Current.Value;

            if (_health.Current.Value <= 0)
                Destroy(gameObject);
        }
    }
}
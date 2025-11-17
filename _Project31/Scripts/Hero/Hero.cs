using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Hero : MonoBehaviour,IHeroDamageble
    {
        public event Action Dead;
        
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        [SerializeField] private Transform _pointToShoot;
        [SerializeField] private Projectile _projectilePrefab;
        
        private Health _health;
        private Mover _mover;
        private Rotator _rotator;
        private Shooter _shooter;
        private float _fixedTime ;

        public bool IsDead => _health.Current.Value <= 0;

        public void Initialize(Mover mover, Rotator rotator, Shooter shooter, Health health)
        {
            _mover = mover;
            _rotator = rotator;
            _shooter = shooter;
            _health = health;
            _fixedTime = Time.fixedDeltaTime;
        }

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
            
            _mover?.SetDirection(direction);
            _rotator?.SetDirection(direction);
            
            _mover?.Update(Time.deltaTime);
            _rotator?.Update(Time.deltaTime);
            _shooter?.Update(_fixedTime);
            
            if(Input.GetKeyDown(KeyCode.Space))
                Shoot(_pointToShoot.position, transform.forward);
        }

        public void Shoot(Vector3 startPosition, Vector3 direction)
            =>_shooter?.Shoot(startPosition,direction);


        public void TakeDamage(float damage)
        {
            _health.Reduce(damage);
            
            if (_health.Current.Value <= 0)
                Dead?.Invoke();

        }
    }
}
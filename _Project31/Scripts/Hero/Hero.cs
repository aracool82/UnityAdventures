using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Hero : MonoBehaviour,IDamageble
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        [SerializeField] private Transform _pointToShoot;
        [SerializeField] private Projectile _projectilePrefab;
        
        private Health _health;
        private Mover _mover;
        private Rotator _rotator;
        private Shooter _shooter;
        private float _fixedTime ;
        public Vector3 Direction => _mover.Direction;

        public void Initialize(Mover mover, Rotator rotator, Shooter shooter, Health health)
        {
            _mover = mover;
            _rotator = rotator;
            _shooter = shooter;
            _health = health;
        }

        private void Awake()
        {
            Initialize(new Mover(transform, 10),
                new Rotator(transform, 600),
                new Shooter(_projectilePrefab),
                new Health(500, 500));
            
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
                Shoot(_pointToShoot.transform.position,transform.forward);
        }

        public void Shoot(Vector3 startPosition, Vector3 direction)
        {
            _shooter?.Shoot(startPosition,direction);
        }


        public void TakeDamage(float damage)
        {
            if (_health.Current.Value <= 0)
            {
                Debug.Log("Hero is Dead");
                return;
            }

            _health.Reduce(damage);
        }
    }
}
using UnityEngine;

namespace _Project31.Scripts
{
    public class Shooter
    {
        private Projectile _projectilePrefab;
        private Projectile _projectile;
        private Vector3 _direction;
        
        public Shooter(Projectile projectilePrefab)
        {
            _projectilePrefab = projectilePrefab;
        }

        public void Shoot( Vector3 startPoint, Vector3 direction )
        {
            _direction = direction;
            _projectile = Object.Instantiate(_projectilePrefab, startPoint, Quaternion.identity,null);
            _projectile.Initialize(100,1,500);
        }

        public void Update(float deltaTime)
        {
            if(_projectile == null)
                return;
            
            _projectile.transform.Translate(_direction * (deltaTime * 100), Space.Self);
        }
    }
}
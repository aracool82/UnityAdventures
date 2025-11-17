using UnityEngine;

namespace _Project31.Scripts
{
    public class Shooter
    {
        private ProjectileSpawner _projectileSpawner;
        private Projectile _projectile;
        private ProjectileConfig _projectileConfig;
        private Vector3 _direction;

        public Shooter(ProjectileSpawner projectileSpawner, ProjectileConfig config)
        {
            _projectileSpawner = projectileSpawner;
            _projectileConfig = config;
        }

        public void Shoot(Vector3 startPoint, Vector3 direction)
        {
            _direction = direction;
            _projectile = _projectileSpawner.Create(_projectileConfig,startPoint);
            //_projectile.transform.position = startPoint;
        }

        public void Update(float deltaTime)
        {
            if (_projectile == null)
                return;

            if (_projectile.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddForce(_direction * (_projectileConfig.Speed * deltaTime), ForceMode.Impulse);
        }
    }
}
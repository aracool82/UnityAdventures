using System.Collections.Generic;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Shooter
    {
        private Projectile _projectilePrefab;
        private Stack<Projectile> _projectiles = new Stack<Projectile>();
        private Vector3 _direction;
        private float _force = 1000;

        public Shooter(Projectile projectilePrefab)
        {
            _projectilePrefab = projectilePrefab;
        }

        public void Shoot(Vector3 startPoint, Vector3 direction)
        {
            _direction = direction;
            Projectile projectile = Object.Instantiate(_projectilePrefab, startPoint, Quaternion.identity, null);
            projectile.Initialize(100, 1, 500);
            _projectiles.Push(projectile);
        }

        public void Update(float deltaTime)
        {
            if (_projectiles.Count == 0)
                return;
            
            if (_projectiles.Pop().TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.AddForce(_direction * (_force * deltaTime), ForceMode.Impulse);
            }
        }
    }
}
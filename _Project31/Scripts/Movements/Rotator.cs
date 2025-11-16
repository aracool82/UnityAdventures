using UnityEngine;

namespace _Project31.Scripts
{
    public class Rotator
    {
        private float _speedRotation;
        private Transform _transform;
        private Vector3 _direction;

        public Rotator(Transform transform, float speedRotation)
        {
            _speedRotation = speedRotation;
            _transform = transform;
        }

        public void Update(float deltaTime)
        {
            if (_direction == Vector3.zero)
                return;

            Quaternion targetRotation = Quaternion.LookRotation(_direction);
            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, targetRotation, _speedRotation);
        }

        public void SetDirection(Vector3 direction)
            => _direction = direction;
    }
}
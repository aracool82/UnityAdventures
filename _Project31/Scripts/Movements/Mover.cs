using UnityEngine;

namespace _Project31.Scripts
{
    public class Mover
    {
        private Transform _transform;
        private float _speedMovement;
        private Vector3 _direction;

        public Mover(Transform transform, float speedMovement)
        {
            _transform = transform;
            _speedMovement = speedMovement;
        }

        public Vector3 Direction => _direction;

        public void Update(float deltaTime)
        {
            if (_direction == Vector3.zero)
                return;
            
            _direction = _direction * (_speedMovement * deltaTime);
            _transform.Translate(_direction, Space.World);

        }

        public void SetDirection(Vector3 direction)
            => _direction = direction;
    }
}
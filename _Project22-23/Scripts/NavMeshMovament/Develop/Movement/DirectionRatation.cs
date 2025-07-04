using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class DirectionRotator
    {
        private Transform _source;
        private float _rotationSpeed;
        private Vector3 _currentDirection;

        public DirectionRotator(Transform source, float rotationSpeed)
        {
            _source = source;
            _rotationSpeed = rotationSpeed;
        }

        public Quaternion CurrentRotation =>_source.rotation;

        public void SetDirection(Vector3 direction)
            => _currentDirection = direction;

        public virtual void Update(float deltaTime)
        {
            if (_currentDirection == Vector3.zero)
                return;

            float step = _rotationSpeed * deltaTime;
            Quaternion lookRotation = Quaternion.LookRotation(_currentDirection);
            _source.rotation = Quaternion.RotateTowards(_source.rotation, lookRotation, step);
        }
    }
}

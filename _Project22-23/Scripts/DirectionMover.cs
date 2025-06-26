using UnityEngine;

namespace _Project22_23.Scripts
{
    public class DirectionMover
    {
        private CharacterController _characterController;
        private float _movementSpeed;
        private Vector3 _direction;

        public DirectionMover(CharacterController characterController, float movementSpeed)
        {
            _characterController = characterController;
            _movementSpeed = movementSpeed;
        }

        public Vector3 Velocity { get; private set; }
        public bool IsMoving => _direction != Vector3.zero;

        public void SetDirection(Vector3 direction)
            => _direction = direction;

        public virtual void Update(float deltaTime)
        {
            if (_direction == Vector3.zero)
            {
                Velocity = Vector3.zero;
                return;
            }

            Velocity = _direction.normalized * _movementSpeed;
            _characterController.Move(Velocity * deltaTime);
            Debug.Log(_characterController.transform.position);
        }
    }
} 
using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public  class DirectionMover
    {
        private CharacterController _characterController;
        private float _movementSpeed;
        private Vector3 _direction;

        public DirectionMover( CharacterController characterController,float movementSpeed)
        {
            _movementSpeed = movementSpeed;
            _characterController = characterController;
        }

        public Vector3 CurrentVelocity { get; private set; }
        public bool IsMoved => _direction != Vector3.zero;

        public void SetDirection(Vector3 direction)
            => _direction = direction;

        public virtual void Update(float deltaTime)
        {
            if (_direction == Vector3.zero)
            {
                CurrentVelocity = Vector3.zero;
                return;
            }

            CurrentVelocity = _direction * _movementSpeed ;
            _characterController.Move(CurrentVelocity * deltaTime);
        }
    }
}
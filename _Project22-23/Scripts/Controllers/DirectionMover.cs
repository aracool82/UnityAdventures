using UnityEngine;

namespace _Project22_23.Scripts
{
    public abstract class DirectionMover
    {
        protected CharacterController CharacterController;
        private float _movementSpeed;
        private Vector3 _direction;

        public DirectionMover(CharacterController characterController, float movementSpeed)
        {
            CharacterController = characterController;
            _movementSpeed = movementSpeed;
        }

        public Vector3 Velocity {get; private set; }
        public Vector3 Direction => _direction;
        
        protected void SetDirection(Vector3 direction)
            => _direction = direction;

        public virtual void Update(float deltaTime)
        {
            if (_direction== Vector3.zero)
            {
                Velocity = Vector3.zero;
                return;
            }

            
            Velocity = _direction.normalized * _movementSpeed;
            CharacterController.Move(Velocity * deltaTime);
        }
    }
}
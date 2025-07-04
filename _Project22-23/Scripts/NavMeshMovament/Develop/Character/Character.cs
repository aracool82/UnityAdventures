using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class Character : MonoBehaviour,IDirectionalMovable,IDirectionalRotatable
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 900f;

        private DirectionRotator _rotator;
        private DirectionMover _mover;

        public bool IsMoved => _mover.CurrentVelocity != Vector3.zero;
        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public Transform Transform => transform;
        
        private void Awake()
        {
            _mover = new DirectionMover(GetComponent<CharacterController>(), _moveSpeed);
            _rotator = new DirectionRotator(transform, _rotationSpeed);
        }

        private void Update()
        {
            _mover.Update(Time.deltaTime);
            _rotator.Update(Time.deltaTime);
        }

        public void SetMoveDirection(Vector3 direction)
            =>_mover.SetDirection(direction);


        public void SetRotationDirection(Vector3 direction)
            =>_rotator.SetDirection(direction);
    }
}
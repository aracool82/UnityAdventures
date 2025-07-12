using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class Character : MonoBehaviour, IDirectionalMovable, IDirectionalRotatable, IDamageble
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 900f;
        [SerializeField] private CharacterView _view;
        [SerializeField] private float _maxHealth = 120;

        private DirectionRotator _rotator;
        private DirectionMover _mover;
        private Health _health;

        public float Health => _health.Value;
        public float MaxHealth => _health.MaxHealth;
        public bool IsMoved => _mover.CurrentVelocity != Vector3.zero;
        public bool IsAlive => _health.IsAlive;
        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public Transform Transform => transform;

        private void Awake()
        {
            _health = new Health(_maxHealth);
            _mover = new DirectionMover(GetComponent<CharacterController>(), _moveSpeed);
            _rotator = new DirectionRotator(transform, _rotationSpeed);
        }

        private void Update()
        {
            if (IsAlive)
            {
                _mover.Update(Time.deltaTime);
                _rotator.Update(Time.deltaTime);
            }
        }

        public void SetMoveDirection(Vector3 direction)
            => _mover.SetDirection(direction);


        public void SetRotationDirection(Vector3 direction)
            => _rotator.SetDirection(direction);


        public void TakeDamage(float amount)
        {
            _health.TakeDamage(amount);
            _view.SetAnimationTakeDamage();
        }
    }
}
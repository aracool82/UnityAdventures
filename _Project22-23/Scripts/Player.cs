using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    public class Player : MonoBehaviour, IDamageble
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 500f;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private float _maxHealth = 120f;

        private PathMover _mover;
        private Rotator _rotator;
        private Health _health;

        public Vector3 Position => transform.position;
        public Vector3 Velocity => _mover.Velocity;
        public bool IsAlive => _health.IsAlive;
        public float Health => _health.Value;
        public float MaxHealth => _health.MaxHealth;
        public bool IsMoving => _mover.IsMovementCoplite == false;

        private bool IsPressedLeftMouseButton => Input.GetMouseButton(0);

        private void Awake()
        {
            _health = new Health(_maxHealth);
            _mover = new PathMover(GetComponent<CharacterController>(), _moveSpeed);
            _rotator = new Rotator(transform, _rotationSpeed);
        }

        private void Update()
        {
            if (IsAlive == false)
                return;

            _mover.Update(Time.deltaTime);

            _rotator.SetInputDirection(_mover.Direction);
            _rotator.Update(Time.deltaTime);
        }

        public void SetPath(NavMeshPath path)
            => _mover.SetPath(path);

        public void TakeDamage(float amount)
        {
            _health.TakeDamage(amount);

            if (_health.Value > 0)
                _playerView.PlayTakeDamageAnimation();
            else
                _playerView.PlayDeadAnimation();
        }
    }
}
//using _Project22_23.Scripts.NewNavMeshScripts.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    /*[RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IDamageble
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 500f;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private float _maxHealth = 120f;

        private CompositeController _mover;
        private Health _health;

        public Vector3 Position => transform.position;
        public Vector3 Velocity => _mover.Velocity;
        public bool IsAlive => _health.IsAlive;
        public float Health => _health.Value;
        public float MaxHealth => _health.MaxHealth;
        public bool IsMoving => _mover.IsMoving;

        private void Awake()
        {
            _health = new Health(_maxHealth);
            
            CharacterController characterController = GetComponent<CharacterController>();
            
            _mover = new CompositeController
                (new DirectionMover(characterController,_moveSpeed),
                new DirectionRotator(transform,_rotationSpeed),transform);
        }
        
        private void Update()
        {
            if (IsAlive == false)
                return;
            
            _mover.Update(Time.deltaTime);
        }

        public void SetPath(NavMeshPath path)
        {
            _mover.SetPath(path);
        }

        public void TakeDamage(float amount)
        {
            _health.TakeDamage(amount);

            if (_health.Value > 0)
                _characterView.PlayTakeDamageAnimation();
            else
                _characterView.PlayDeadAnimation();
        }
    }*/
}
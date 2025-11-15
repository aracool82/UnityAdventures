using UnityEngine;

namespace _Project31.Scripts
{
    public class Hero : MonoBehaviour
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        [SerializeField] private Transform _pointToShoot;
        
        private Health _health;
        private Mover _mover;
        private Rotator _rotator;
        private Shooter _shooter;
        
        private void Awake()
        {
            _mover = new Mover(transform, 10);
            _rotator = new Rotator(transform, 600);
            _health = new Health();
            _shooter = new Shooter();
        }

        private void Update()
        {
            Vector3 direction = new Vector3(Input.GetAxis(Horizontal), 0, Input.GetAxis(Vertical));
            
            _mover?.SetDirection(direction);
            _rotator?.SetDirection(direction);
            
            _mover?.Update(Time.deltaTime);
            _rotator?.Update(Time.deltaTime);
        }

        public void Shoot(Vector3 direction)
        {
            _shooter.Shoot(_pointToShoot.position,transform.forward);
        }
    }
}
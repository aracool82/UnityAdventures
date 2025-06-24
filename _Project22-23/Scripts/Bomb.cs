using UnityEngine;

namespace _Project22_23.Scripts
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _ditonationRadius;
        [SerializeField] private float _ditonationTime;
        [SerializeField] private float _damage;
        [SerializeField] private SphereCollider _collider;

        private float _timer;
        private bool _isStartTimer;
        private IDamageble _damageble;
        private float _multiplier = 2;
        
        public bool IsDetonated => _timer >= _ditonationTime;
        
        private void Awake()
        {
            _collider.radius = _ditonationRadius * _multiplier;
        }

        private void Update()
        {
            if (_isStartTimer == false)
                return;

            _timer += Time.deltaTime;

            if (_timer >= _ditonationTime)
            {
                _timer = 0;
                Detonate();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageable))
            {
                if (damageable.IsAlive)
                {
                    _isStartTimer = true;
                    _damageble = damageable;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageable))
            {
                _isStartTimer = false;
                _damageble = null;
                _timer = 0;
            }
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _ditonationRadius);
            }
        }

        private void OnDestroy()
            => _damageble = null;

        private void Detonate()
        {
            if (_damageble != null && _damageble.IsAlive)
            {
                _damageble.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
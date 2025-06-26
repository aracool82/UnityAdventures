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
        private bool _isRunTimer;
        private float _multiplier = 2;

        private void Awake()
            =>_collider.radius = _ditonationRadius * _multiplier;

        private void Update()
        {
            if (_isRunTimer == false)
                return;

            _timer += Time.deltaTime;

            if (_timer >= _ditonationTime)
                Detonate();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageable))
                if (damageable.IsAlive)
                    _isRunTimer = true;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _ditonationRadius);
            }
        }

        private void Detonate()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _ditonationRadius);

            foreach (Collider collider in colliders)
                if(collider.TryGetComponent(out IDamageble damageable))
                    damageable.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}
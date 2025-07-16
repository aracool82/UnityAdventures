using System.Collections;
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private float _ditonationRadius;
        [SerializeField] private float _ditonationTime;
        [SerializeField] private float _damage;
        [SerializeField] private SphereCollider _collider;
        
        private Coroutine _coroutine;
        private float _multiplier = 2;

        private void Awake()
            =>_collider.radius = _ditonationRadius * _multiplier;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageable))
                if (damageable.IsAlive)
                    if (_coroutine == null)
                        _coroutine = StartCoroutine(StartDetonation(_ditonationTime));
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _ditonationRadius);
            }
        }

        private IEnumerator StartDetonation(float waitTime)
        {
            YieldInstruction wait = new WaitForSeconds(waitTime);
            yield return wait;
            Detonate();
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
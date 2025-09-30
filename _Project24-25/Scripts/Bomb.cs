using System.Collections;
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioClip _clip;
        
        [SerializeField] private float _ditonationRadius;
        [SerializeField] private float _ditonationTime;
        [SerializeField] private float _damage;
        [SerializeField] private SphereCollider _collider;

        private Coroutine _coroutineDetanation;
        private Coroutine _coroutineStartDetonation;

        private void Awake()
            => _collider.radius = _ditonationRadius;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageable))
                if (damageable.IsAlive)
                    if (_coroutineStartDetonation == null)
                        _coroutineStartDetonation = StartCoroutine(StartDetonationWithWait(_ditonationTime));
        }

        private IEnumerator StartDetonationWithWait(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            Detonate();
        }

        private void Detonate()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _ditonationRadius);

            foreach (Collider collider in colliders)
                if (collider.TryGetComponent(out IDamageble damageable))
                    damageable.TakeDamage(_damage);

            _audioManager.PlayOneShotClip(_clip);
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, _ditonationRadius);
            }
        }
    }
}
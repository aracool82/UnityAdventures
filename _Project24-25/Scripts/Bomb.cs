using System.Collections;
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class Bomb : MonoBehaviour
    {
        private const float MinScaleSpeed = 0;
        private const float MaxScaleSpeed = 15;
        private const string ScaleProperty = "_SpeedScale";
        
        [SerializeField] private Renderer _renderer;

        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioClip _clip;

        [SerializeField] private float _ditonationRadius;
        [SerializeField] private float _ditonationTime;
        [SerializeField] private float _damage;
        [SerializeField] private SphereCollider _collider;
        
        private Material[] _materials;
        private Coroutine _coroutineDetanation;
        private Coroutine _coroutineStartDetonation;

        private void Awake()
        {
            _collider.radius = _ditonationRadius;
            _renderer = GetComponentInChildren<Renderer>();
            _materials = _renderer.materials;
            SetScaleSpeed(MinScaleSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageble damageable))
                if (damageable.IsAlive)
                    if (_coroutineStartDetonation == null)
                        _coroutineStartDetonation = StartCoroutine(StartDetonationWithWait(_ditonationTime));
        }

        private IEnumerator StartDetonationWithWait(float waitTime)
        {
            SetScaleSpeed(MaxScaleSpeed);
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

        private void SetScaleSpeed(float speed)
        {
            foreach (Material material in _materials)
                material.SetFloat(ScaleProperty, speed);
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
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _boomEffectPrefab;
        [SerializeField] private float _power;
        [SerializeField] private float _upwardsModifier;

        private ParticleSystem _boomEffect;

        private void Awake()
        {
            _boomEffect = Instantiate(_boomEffectPrefab, Vector3.zero, Quaternion.identity, null);
        }

        public void Explode(Vector3 point, float radius, Collider[] colliders)
        {
            if (colliders.Length == 0)
                return;

            foreach (Collider collider in colliders)
                if (collider.TryGetComponent(out Rigidbody rigidbody))
                    rigidbody.AddExplosionForce(_power, point, radius, _upwardsModifier, ForceMode.Impulse);

            PlayEffect(point);
        }

        private void PlayEffect(Vector3 position)
        {
            _boomEffect.transform.position = position;
            _boomEffect.Play();
        }
    }
}
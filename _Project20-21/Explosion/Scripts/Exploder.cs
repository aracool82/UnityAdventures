using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Exploder
    {
        private ParticleSystem _boomEffect;
        private float _power;
        private float _upwardsModifier;

        public  Exploder(ParticleSystem boomEffect, float power, float upwardsModifier)
        {
            _boomEffect = boomEffect;
            _power = power;
            _upwardsModifier = upwardsModifier;
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
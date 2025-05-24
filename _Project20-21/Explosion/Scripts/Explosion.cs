using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Explosion
    {
        private float _radius;
        private float _power;
        private float _upwardsModifier;
        private Collider[] _colliders;
        private ParticleSystem _boomEffect;

        public Explosion(float radius, float power, ParticleSystem boomEffect)
        {
            _radius = radius;
            _power = power;
            _boomEffect = boomEffect;
            _upwardsModifier = 1.0f;
        }

        public void Explode(Vector3 position)
        {
            _colliders = Physics.OverlapSphere(position, _radius);
            StartExplode(position);
        }

        private void StartExplode(Vector3 position)
        {
            foreach (Collider collider in _colliders)
                if (collider.TryGetComponent(out IExploded exploded))
                    exploded.Rigidbody.AddExplosionForce(_power, position, _radius, _upwardsModifier, ForceMode.Impulse);
            
            PlayEffect(position);
        }

        private void PlayEffect(Vector3 position)
        {
            ParticleSystem boom = GameObject.Instantiate(_boomEffect, position, Quaternion.identity,null);
            boom.Play();
        }
    }
}
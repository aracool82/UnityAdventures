using UnityEngine;

namespace _Project14_15.Scripts
{
    public class Bullet : Item
    {
        [Range(5f,50f)]
        [SerializeField] private float _speed;
        
        [Range(0.5f,5f)]
        [SerializeField] private float _timeToDestroy;

        private Vector3 _direction;
        private bool _canFly;
        private float _timerCounter;

        private void Update()
        {
            if (_canFly == false)
                return;

            _timerCounter += Time.deltaTime;

            if (_timerCounter >= _timeToDestroy)
            {
                ParticleEffect.Stop();
                ParticleEffect.transform.SetParent(null);
                Desroy();
            }

            Fly();
        }

        public override void Use(GameObject character)
        {
            if(character.TryGetComponent(out Character characterComponent))
            {
                if (transform.IsChildOf(characterComponent.transform))
                {
                    _direction = characterComponent.transform.forward;

                    transform.SetParent(null);
                    _canFly = true;
                    ParticleEffect.transform.SetParent(transform);

                    StartEffect(transform.position);
                }
            }
        }

        private void Fly()
            => transform.position += _direction * (_speed * Time.deltaTime);
    }
}
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Dead : IBehavior
    {
        private ParticleSystem _deadEffect;
        private GameObject _gameObject;
        private float _timer;
        private bool _isTrarted;
        
        public Dead(GameObject gameObject, ParticleSystem deadEffect)
        {
            _deadEffect = deadEffect;
            _gameObject = gameObject;
            _isTrarted = false;
            _timer = 0.05f;
        }

        public void Update()
        {
            if (_isTrarted == false)
                return;
            
            _timer -= Time.deltaTime;
            
            if(_timer <= 0)
                DestroyObject();
        }

        public void DoAction()
        {
            PlayEffect();
            _isTrarted = true;
        }

        private void DestroyObject()
            => GameObject.Destroy(_gameObject);

        private void PlayEffect()
            => _deadEffect.Play();
    }
}
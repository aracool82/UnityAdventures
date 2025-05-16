using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorDead : IBehavior
    {
        private ParticleSystem _deadEffect;
        private GameObject _source;
        private float _destroyTime;

        public ReactionBehaviorDead(GameObject source, ParticleSystem deadEffect)
        {
            _source = source;
            _deadEffect = deadEffect;
            _destroyTime = 0.1f;
            IsEnabled = true;
        }
        
        public Behaviors Movement => Behaviors.Dead;
        public bool IsEnabled { get; private set; }

        public void Update()
        {
            if (IsEnabled == false)
                return;

            IsEnabled = false;
            _deadEffect.transform.position = _source.transform.position;
            PlayEffect();

            GameObject.Destroy(_source, _destroyTime);
        }

        public void DoAction()
        {
            Update();
        }

        private void DestroyObject()
            => GameObject.Destroy(_source);

        private void PlayEffect()
        {
            Debug.Log($"Playing Effect  {_deadEffect.name}");
            _deadEffect.Play();
        }
    }
}
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
        }
        
        public Behaviors Movement => Behaviors.Dead;

        public void Update()
        {
            _deadEffect.transform.position = _source.transform.position;
            
            _deadEffect.Play();
            GameObject.Destroy(_source, _destroyTime);
        }
    }
}
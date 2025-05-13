using Unity.VisualScripting;
using UnityEngine;

namespace _Project16_17.Scripts
{
    [RequireComponent(typeof(AggressionDetector))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private State _state;
        [SerializeField] private Rest _rest;
        [SerializeField] private Reaction _reaction;
        
        [SerializeField] private ParticleSystem _deadEffectPrefab;
        private IBehavior _behavior;
        private AggressionDetector _aggressionDetector;

        public void Initialize(Transform characterTransform,ParticleSystem deadEffectPrefab)
        {
            float distance = 4;
            _aggressionDetector = GetComponent<AggressionDetector>();

            if (_aggressionDetector == null)
                Debug.LogError("Aggression Detector Component is missing");

            _aggressionDetector.Initialize(characterTransform, transform, distance);

            _state = State.AtRest;
            
            ParticleSystem deadEffect = Instantiate(deadEffectPrefab,transform);
            _behavior = new Dead(gameObject, deadEffect);
        }

        private void Update()
        {
            _behavior.Update();
            _state = _aggressionDetector.IsDecected ? State.Reaction : State.AtRest;
            
            if(_state == State.AtRest)
                _behavior.DoAction();
        }
    }
}
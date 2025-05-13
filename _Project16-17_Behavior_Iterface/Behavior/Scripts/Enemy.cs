using UnityEngine;

namespace _Project16_17.Scripts
{
    [RequireComponent(typeof(AggressionDetector))]
    public class Enemy : MonoBehaviour
    {
        private Stats stats;
        private Rests rests;
        private Reactions reactions;

        [SerializeField] private ParticleSystem _deadEffectPrefab;
        private IBehavior _behavior;
        private AggressionDetector _aggressionDetector;

        public void Initialize(Transform characterTransform, ParticleSystem deadEffectPrefab)
        {
            float distance = 4;
            _aggressionDetector = GetComponent<AggressionDetector>();

            if (_aggressionDetector == null)
                Debug.LogError("Aggression Detector Component is missing");

            _aggressionDetector.Initialize(characterTransform, transform, distance);

            stats = Stats.AtRest;

            ParticleSystem deadEffect = Instantiate(deadEffectPrefab, transform);
            _behavior = new Dead(gameObject, deadEffect);
        }

        private void Update()
        {
            stats = _aggressionDetector.IsDecected ? Stats.Reaction : Stats.AtRest;

            if (stats == Stats.AtRest)
                _behavior.DoAction();
        }
    }
}
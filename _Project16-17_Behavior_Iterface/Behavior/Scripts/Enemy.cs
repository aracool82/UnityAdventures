using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Stats stats;
        [SerializeField] private float _targetDistance;

        private AggressionDetector _aggressionDetector;

        private IBehavior _behaviorRest;
        private IBehavior _behaviorReaction;

        private Transform _target;

        public void Initialize(Transform target)
        {
            if( Utils.Validator.IsValidReference(target))
            {
                _target = target;
                _aggressionDetector = new AggressionDetector(target, transform);
            }
        }

        private void Update()
        {
            _targetDistance = _aggressionDetector.TargetDistance;
            _aggressionDetector.Update(_target, transform);

            stats = _aggressionDetector.IsDecected ? Stats.Reaction : Stats.AtRest;

            if (stats == Stats.AtRest)
                _behaviorRest.Update();
            else if (stats == Stats.Reaction)
                _behaviorReaction.Update();
            else
                Debug.LogError("Unknown stats");
        }

        public void SetBehaviorsRest(IBehavior behaviorRest)
        {
            if (Utils.Validator.IsValidReference(behaviorRest))
                _behaviorRest = behaviorRest;
        }

        public void SetBehaviorsReaction(IBehavior behaviorReaction)
        {
            if (Utils.Validator.IsValidReference(behaviorReaction))
                _behaviorReaction = behaviorReaction;
        }
    }
}
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

        private Reactions _reaction;
        private Rests _rest;

        public void Initialize(Transform target, Reactions reaction, Rests rest)
        {
            _reaction = reaction;
            _rest = rest;

            _target = target;
            _aggressionDetector = new AggressionDetector(target, transform);
        }

        private void Update()
        {
            _targetDistance = Vector3.Distance(transform.position, _target.position);
            _aggressionDetector.Update(_target, transform);

            stats = _aggressionDetector.IsDecected ? Stats.Reaction : Stats.AtRest;

            if (stats == Stats.AtRest)
                _behaviorRest.Update();
            else if (stats == Stats.Reaction)
                _behaviorReaction.Update();
        }

        public void SetBehaviorsRest(IBehavior behaviorRest)
        {
            if (IsValidBehavior(behaviorRest))
                _behaviorRest = behaviorRest;
        }

        public void SetBehaviorsReaction(IBehavior behaviorReaction)
        {
            if (IsValidBehavior(behaviorReaction))
                _behaviorReaction = behaviorReaction;
        }

        private bool IsValidBehavior(IBehavior behavior)
        {
            if (behavior == null)
            {
                Debug.LogError("Behavior is null");
                return false;
            }

            return true;
        }
    }
}
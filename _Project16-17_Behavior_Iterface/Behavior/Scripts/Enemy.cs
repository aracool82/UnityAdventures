using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _targetDistance;

        private AggressionDetector _aggressionDetector;

        private IBehavior _behaviorRest;
        private IBehavior _behaviorReaction;
        private IBehavior _currentBehavior;

        private Transform _target;

        public void Initialize(Transform target, AggressionDetector aggressionDetector)
        {
            _target = target;
            _aggressionDetector = aggressionDetector;
        }

        private void Update()
        {
            _targetDistance = _aggressionDetector.TargetDistance;
            _aggressionDetector.Update(_target, transform);

            if (_aggressionDetector.IsDecected)
                _currentBehavior = _behaviorReaction;
            else
                _currentBehavior = _behaviorRest;

            _currentBehavior.Update();
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
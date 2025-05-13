using UnityEngine;

namespace _Project16_17.Scripts
{
    public class AggressionDetector : MonoBehaviour
    {
        private Transform _targetPosition;
        private Transform _sourcePosition;
        private float _aggressionDistance;

        public void Initialize(Transform target, Transform source, float aggressionDistance)
        {
            _targetPosition = target;
            _sourcePosition = source;
            _aggressionDistance = aggressionDistance;
        }

        public bool IsDecected 
            => GetDistance() <= _aggressionDistance;

        private float GetDistance()
            => (_targetPosition.position - _sourcePosition.position).magnitude;
    }
}
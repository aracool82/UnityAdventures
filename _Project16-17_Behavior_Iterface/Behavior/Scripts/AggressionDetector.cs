using UnityEngine;

namespace _Project16_17.Scripts
{
    public class AggressionDetector
    {
        private const float AggressionDistance = 3f;
        
        private Transform _source;
        private Transform _target;
        
        public AggressionDetector(Transform target, Transform source)
        {
            if(Utils.Validator.IsValidReference(target) && Utils.Validator.IsValidReference(source))
            {
                _target = target;
                _source = source;
            }
        }

        public float TargetDistance => GetDistance();
        public bool IsDecected => GetDistance() <= AggressionDistance;

        public void Update(Transform target, Transform source)
        {
            _target = target;
            _source = source;
        }

        private float GetDistance()
            => Vector3.Distance(_source.position, _target.position);
    }
}
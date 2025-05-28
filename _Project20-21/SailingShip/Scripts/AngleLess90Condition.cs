using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class AngleLess90Condition
    {
        private const float _angle = 90f; 
        private Transform _source;

        public AngleLess90Condition(Transform source)
        {
            _source = source;
        }

        private Vector3 _currenDirection =>_source.forward;
        
        public bool IsCompleteCondition(Vector3 targetDirection)
        {
            float dot = Vector3.Dot(_currenDirection, targetDirection);
            float cos = dot / (_currenDirection.magnitude * targetDirection.magnitude);
            float angle = Mathf.Acos(cos)*Mathf.Rad2Deg;

            if (angle < _angle)
                return true;

            return false;
        }
    }
}
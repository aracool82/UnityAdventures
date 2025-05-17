using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Mover
    {
        private Transform _source;

        public Mover(Transform source, float speed)
        {
            if (Utils.Validator.IsValidReference(source))
                _source = source;

            if (Utils.Validator.IsValidFLoat(speed))
                Speed = speed;
        }

        public float Speed { get; private set; }

        public void MoveToDirection(Vector3 direction)
        {
            _source.Translate(direction * (Speed * Time.deltaTime), Space.World);
            _source.rotation = Quaternion.LookRotation(direction);
        }

        public bool TryGetDirection(Transform target, out Vector3 direction)
        {
            if (!Utils.Validator.IsValidReference(target))
            {
                direction = Vector3.zero;
                return false;
            }

            direction = (target.transform.position - _source.position).normalized;
            
            return true;
        }
    }
}
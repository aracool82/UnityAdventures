using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Mover : IUpdateble
    {
        private float _minDistanceToTarget;
        private Transform _source;

        private Transform _target;
        private bool _canMoveToTarget;

        public float Speed { get; private set; }

        public Mover(Transform source, float speed, float minDistanceToTarget = 0.5f)
        {
            _source = source;

            if (IsLessZeroFloat(speed) )
                speed = 0;

            if (IsLessZeroFloat(minDistanceToTarget))
                minDistanceToTarget = 0.5f;

            Speed = speed;
            _minDistanceToTarget = minDistanceToTarget;
            _canMoveToTarget = false;
        }

        public void Update()
        {
            if (_canMoveToTarget == false)
                return;

            if (IsReachedTarget(_target.position) == false)
                MoveToDirection(GetDirection(_target.position));
            else
                _canMoveToTarget = false;
        }

        public void MoveToDirection(Vector3 direction)
        {
            _source.Translate(direction * (Speed * Time.deltaTime), Space.World);
            _source.rotation = Quaternion.LookRotation(direction);
        }

        public void MoveToTarget(Transform target)
        {
            if (target == null)
            {
                Debug.LogError("Target is null");
                return;
            }

            _target = target;
            _canMoveToTarget = true;
        }

        public void SetSpeed(float speed)
        {
            if (IsLessZeroFloat(speed) == false)
                Speed = speed;
            else
                Debug.LogError("Speed can't be less than 0");
        }

        private bool IsReachedTarget(Vector3 target)
            => (_source.position - target).magnitude <= _minDistanceToTarget;

        private Vector3 GetDirection(Vector3 target)
            => (target - _source.position).normalized;

        private bool IsLessZeroFloat(float value)
            => value < 0;
    }
}
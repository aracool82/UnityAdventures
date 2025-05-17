using System.Collections.Generic;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class RestBehaviorPatroll : IBehavior
    {
        private const float MinDistanceToTarget = .2f;

        private List<Transform> _points = new List<Transform>();
        private Queue<Transform> _waypoints = new Queue<Transform>();
        private Transform _target;
        private Mover _mover;
        private Transform _source;


        public RestBehaviorPatroll(Transform source, List<Transform> points,float speed)
        {
            if (Utils.Validator.IsValidReference(points) && Utils.Validator.IsValidReference(source) && Utils.Validator.IsValidFLoat(speed))
            {
                _points = points;
                _source = source;
                CreateQueue();
                _mover = new Mover(source, speed);
            }
        }

        public void Update()
        {
            if (IsReachedTarget())
                _target = GetNextTarget();

            if (_mover.TryGetDirection(_target, out Vector3 direction))
                _mover.MoveToDirection(direction);
        }

        private bool IsReachedTarget()
            => (_source.position - _target.position).magnitude < MinDistanceToTarget;

        private Transform GetNextTarget()
        {
            _target = _waypoints.Dequeue();
            _waypoints.Enqueue(_target);
            return _target;
        }

        private void CreateQueue()
        {
            foreach (Transform point in _points)
                _waypoints.Enqueue(point);

            _target = GetNextTarget();
        }
    }
}
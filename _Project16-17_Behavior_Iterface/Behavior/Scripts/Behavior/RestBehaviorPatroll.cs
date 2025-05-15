using System.Collections.Generic;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class RestBehaviorPatroll : IBehavior
    {
        private List<Transform> _points = new List<Transform>();
        private Transform _curentTarget;
        private Queue<Transform> _waypoints = new Queue<Transform>();
        private ToTargetMover _mover;
        private Transform _source;

        public RestBehaviorPatroll(Transform source, List<Transform> points)
        {
            if (points == null)
                Debug.LogError("Points cannot be null");
            else
            {
                float speed = 3f;
                _points = points;
                _source = source;
                _mover = new ToTargetMover(source);
                IsEnabled = true;
                CreateQueue();
            }
        }

        public bool IsEnabled { get; private set; }

        // public Vector3 GetNextPoint()
        // {
        //     Vector3 point = _points[_curentIndex].position;
        //     _curentIndex = (_curentIndex + 1) % _points.Count;
        //     return point;
        // }

        public void DoAction()
        {
            IsEnabled = true;
        }

        public void Update()
        {
            if (IsEnabled == false)
                return;
            
           if(_mover.IsReachedTarget)
                _curentTarget = GetNextTarget();
           
            _mover.MoveToTarget(_curentTarget);
            
            
            _mover.Update();
        }

        private Transform GetNextTarget()
        {
            _curentTarget = _waypoints.Dequeue();
            _waypoints.Enqueue(_curentTarget);
            return _curentTarget;
        }

        private void CreateQueue()
        {
            foreach (Transform point in _points)
                _waypoints.Enqueue(point);

            _curentTarget = GetNextTarget();
        }
    }
}
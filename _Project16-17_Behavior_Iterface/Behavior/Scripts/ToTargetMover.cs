using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ToTargetMover
    {
        private Transform _sourse;
        private Transform _target;
        private float _speed;
        private float _minDistanceToTarget;
        private bool _canMove;

        public ToTargetMover(Transform sourse)
        {
            _sourse = sourse;
            _speed = 3;
            _minDistanceToTarget = 0.1f;
        }

        public bool IsReachedTarget { get; private set; }

        public void Update()
        {
            if (_canMove == false)
                return;

            float distance = (_target.position - _sourse.position).magnitude; 
            _sourse.transform.position = Vector3.MoveTowards(_sourse.position, _target.position, _speed * Time.deltaTime);
            
            if (distance < _minDistanceToTarget)
            {
                IsReachedTarget = true;
                _canMove = false;
            }
            else
            {
                _canMove = true;
                IsReachedTarget = false;
            }
        }

        public void MoveToTarget(Transform target)
        {
            if (target == null)
            {
                Debug.Log("Target is null");
                return;
            }

            _canMove = true;
            _target = target;
        }
    }
}
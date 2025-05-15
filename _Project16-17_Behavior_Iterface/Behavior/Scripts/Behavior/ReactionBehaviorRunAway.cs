using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorRunAway : IBehavior
    {
        private Transform _source;
        private Transform _target;
        private Mover _mover;
        private Vector3 _directionMove;

        public ReactionBehaviorRunAway(Transform source, Transform target)
        {
            float speed = 3.0f;
            _source = source;
            _target = target;
            _mover = new Mover(source, speed);
        }

        public bool IsEnabled { get; private set; }

        public void Update()
        {
            if (IsEnabled == false)
                return;

            _mover.MoveToDirection(_directionMove);
            _mover.Update();
        }

        public void DoAction()
        {
            //_directionMove = (_target.position - _source.position).normalized;
            _directionMove = (_target.position - _source.position).normalized * -1f;
            IsEnabled = true;
        }
    }
}
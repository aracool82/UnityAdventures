using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorRunAway : IBehavior
    {
        private Transform _source;
        private Transform _target;

        private Mover _mover;

        private Vector3 _directionMove;
        public Reactions _reaction => Reactions.RunAway;

        public ReactionBehaviorRunAway(Transform source, Transform target)
        {
            float speed = 3.0f;
            _source = source;
            _target = target;
            _mover = new Mover(source, speed);
        }

        public Behaviors Movement => Behaviors.RunAway;
        public bool IsEnabled { get; private set; }

        public void Update()
        {
            if (IsEnabled == false)
                return;

            _mover.MoveToDirection(_directionMove);
        }

        public void DoAction()
        {
            Vector3 direction = _source.position - _target.position;
            _directionMove = new Vector3(direction.x, 0, direction.z).normalized;
            IsEnabled = true;
        }
    }
}
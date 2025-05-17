using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorRunAway : IBehavior
    {
        private const float Speed = 3f;
        
        private Transform _source;
        private Transform _target;
        private Mover _mover;

        private Vector3 _directionMove;

        public ReactionBehaviorRunAway(Transform source, Transform target,float speed)
        {
            if(Utils.Validator.IsValidReference(source) && Utils.Validator.IsValidReference(target) && Utils.Validator.IsValidFLoat(speed))
            {
                _source = source;
                _target = target;
                _mover = new Mover(source, speed);
            }
        }

        public void Update()
        {
            Vector3 direction = _source.position - _target.position;
            _directionMove = new Vector3(direction.x, 0, direction.z).normalized;

            _mover.MoveToDirection(_directionMove);
        }
    }
}
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorFollowTo : IBehavior
    {
        private Transform _target;
        private Transform _source;    
        private Mover _mover;

        public ReactionBehaviorFollowTo(Transform source, Transform target,float speed)
        {
            if(Utils.Validator.IsValidReference(source) && Utils.Validator.IsValidReference(target) && Utils.Validator.IsValidFLoat(speed))
            {
                _target = target;
                _mover = new Mover(source, speed);
            }
        }
     
        public void Update()
        {
            if(_mover.TryGetDirection(_target,out Vector3 direction))
                _mover.MoveToDirection(direction);
        }
    }
}
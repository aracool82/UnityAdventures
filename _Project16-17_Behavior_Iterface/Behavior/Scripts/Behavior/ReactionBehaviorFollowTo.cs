using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorFollowTo : IBehavior
    {
        private Transform _target;
        private Transform _source;    
        private ToTargetMover _mover;
        
        private Reactions Reaction => Reactions.FollowToTarget;
        
        public ReactionBehaviorFollowTo(Transform source, Transform target)
        {
            _target = target;
            _mover = new ToTargetMover(source);
        }

        public Behaviors Movement => Behaviors.FollowToTarget;
     
        public void Update()
        {
            _mover.MoveToTarget(_target);
            _mover.Update();
        }
    }
}
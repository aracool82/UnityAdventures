using UnityEngine;

namespace _Project16_17.Scripts
{
    public class ReactionBehaviorFollowTo : IBehavior
    {
        private Transform _target;
        private Transform _source;    
        private ToTargetMover _mover;
        
        public ReactionBehaviorFollowTo(Transform source, Transform target)
        {
            _target = target;
            _mover = new ToTargetMover(source);
            IsEnabled = false;
        }

        public bool IsEnabled { get;private set; }
     
        public void Update()
        {
            if(IsEnabled == false)
                return;
                
            _mover.MoveToTarget(_target);
            _mover.Update();
        }


        public void DoAction()
        {
            IsEnabled = true;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class StrategyMovement 
    {
        private List<IBehavior> _behaviors = new List<IBehavior>();
        
        public StrategyMovement(List<IBehavior> behaviors)
        {
            _behaviors = behaviors;
        }

        public IBehavior GetBehavior(Behaviors movement)
            =>FindBehavior(movement);
         

        private IBehavior FindBehavior(Behaviors movement)
        {
            foreach (IBehavior behavior in _behaviors)
                if(behavior.Movement == movement)
                    return behavior;
            
            Debug.LogError("No Movements Found");
            return null;
        }
    }
}
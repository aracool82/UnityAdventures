
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class StrategyMovement 
    {
        private IBehavior _behavior;
        
        public StrategyMovement(IBehavior behavior)
        {
            _behavior = behavior;
        }
    }
}
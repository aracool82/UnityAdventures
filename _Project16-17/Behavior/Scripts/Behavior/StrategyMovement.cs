using System;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class StrategyMovement : MonoBehaviour
    {
        private IBehavior _behavior;

        public void Initialise(IBehavior behavior)
        {
            _behavior = behavior;
        }
    }
}
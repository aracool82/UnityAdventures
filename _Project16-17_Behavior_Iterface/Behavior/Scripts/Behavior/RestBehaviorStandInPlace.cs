using UnityEngine;

namespace _Project16_17.Scripts
{
    public class RestBehaviorStandInPlace : IBehavior
    {
        private Transform _source;
        private Vector3 _position;
        
        public RestBehaviorStandInPlace(Transform source)
        {
            _source = source;
        }

        public Behaviors Movement => Behaviors.NoMove;
        public bool IsEnabled { get; }

        public void DoAction()
        {
           //_position = _source.position;
        }

        public void Update()
        {
            //_source.position = _position;
        }

    }
}
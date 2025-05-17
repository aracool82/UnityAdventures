using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project16_17.Scripts
{
    public class RestBehaviorRandomMovement : IBehavior
    {
        private float _changeDirectonTime;
        private float _time;

        private List<Vector3> _directions = new() { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
        private Vector3 _direction;

        private Mover _mover;
        private Transform _source;

        public RestBehaviorRandomMovement(Transform source)
        {
            float speed = 3f;
            _mover = new Mover(source, speed);
            _source = source;
            _changeDirectonTime = 1f;
            _direction = _directions[0];
        }

        public Behaviors Movement => Behaviors.RandomDirectionMove;

        
        public void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _changeDirectonTime)
            {
                _time = 0;
                _direction = GetNextDirection();
            }

            _mover.MoveToDirection(_direction);
        }

        public Vector3 GetNextDirection()
            => _directions[Random.Range(0, _directions.Count)];
    }
}
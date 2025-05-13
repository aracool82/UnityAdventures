using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project16_17.Scripts
{
    public class RandomMovement :  IBehavior
    {
        private List<Vector3> _directions = new() { Vector3.forward, Vector3.back, Vector3.right, Vector3.left };
        private float _timer;
        private Vector3 _curentDirection;
        private bool _canMove;
        private Mover _mover;

        public void Init(Mover mover)
        {
            _mover = mover;
        }

        public void Update()
        {
            
        }

        public Vector3 GetNextPoint()
            => _directions[Random.Range(0, _directions.Count)];

        public void DoAction()
        {
            
        }
    }
}
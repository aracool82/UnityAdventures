using System.Collections.Generic;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Patroll : IBehavior
    {
        private List<Vector3> _points = new (){new Vector3(0,0,0),new Vector3(2,0,0),new Vector3(-2,0,0)};
        private int _curentIndex;

        public Vector3 GetNextPoint()
        {
            Vector3 point = _points[_curentIndex];
            _curentIndex = (_curentIndex + 1) % _points.Count;
            return point;
        }

        public void DoAction()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
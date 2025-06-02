using System.Collections.Generic;
using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Rotator
    {
        private Transform _source;
        private float _speed;

        public Rotator(Transform source, float speed)
        {
            _source = source;
            _speed = speed;
        }
        
        public float RotateSpeed => _speed;
        
        public void Rotation(Vector3 direction)
        {
            Quaternion fromRotation = _source.rotation;
            Quaternion toRotation = Quaternion.Euler(direction);
            _source.rotation = Quaternion.RotateTowards(fromRotation, toRotation, _speed * Time.deltaTime);
        }

        public void RotateRight(float deltaTime)
        {
            Vector3 direction = _source.rotation.eulerAngles + Vector3.up;
            Rotation(direction);
        }

        public void RotateLeft(float deltaTime)
        {
            Vector3 direction = _source.rotation.eulerAngles - Vector3.up;
            Rotation( direction);
        }
    }
}
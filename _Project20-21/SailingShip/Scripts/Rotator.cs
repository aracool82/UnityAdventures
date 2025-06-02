using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Rotator : IRoratebleCondition
    {
        private Transform _source;
        private float _speed;
        private Vector3 _rotationAxis;
        private float _angle;

        public Rotator(Transform source, float speed)
        {
            _source = source;
            _speed = speed;
        }

        public void Rotation(float deltaTime, Vector3 direction)
        {
            Quaternion fromRotation = _source.rotation;
            Quaternion toRotation = Quaternion.Euler(direction);
            _source.rotation = Quaternion.RotateTowards(fromRotation, toRotation, _speed * deltaTime);
        }
    }
}
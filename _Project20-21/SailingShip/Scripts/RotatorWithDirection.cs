using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class RotatorWithDirection
    {
        private Transform _source;
        private float _speed;
        

        public RotatorWithDirection(Transform source, float speed)
        {
            _source = source;
            _speed = speed;
        }

        public void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
                return;
            
            _source.rotation = Quaternion.RotateTowards(_source.rotation, Quaternion.Euler(direction), _speed * Time.deltaTime);
        }
    }
}
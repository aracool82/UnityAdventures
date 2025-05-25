using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Rotator : MonoBehaviour
    {
        private Transform _source;
        
        private KeyCode _turnRightKey;
        private KeyCode _turnLeftKey;

        private float _rotationSpeed;
        private float _currentAngle;
        private float _limitAngleY;

        public Rotator(Transform source,float rotationSpeed,KeyCode turnRightKey, KeyCode turnLeftKey, float limitAngleY = 0)
        {
            _source = source;
            _rotationSpeed = rotationSpeed;
            _turnRightKey = turnRightKey;
            _turnLeftKey = turnLeftKey;
            _limitAngleY = limitAngleY;
        }

        private bool IsPressedRightKey => Input.GetKey(_turnRightKey);
        private bool IsPressedLeftKey => Input.GetKey(_turnLeftKey);
        
        public void Update()
        {
            if(IsPressedRightKey )
                RotateTo(_source,Directions.Right);
            
            if(IsPressedLeftKey)
                RotateTo(_source,Directions.Left);
        }

        private void RotateTo(Transform source,Directions direction)
            =>source.Rotate(0, (int)direction * _rotationSpeed * Time.deltaTime, 0);
    }
}
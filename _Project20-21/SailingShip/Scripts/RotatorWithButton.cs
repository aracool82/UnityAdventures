using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class RotatorWithButton
    {
        private const float FullTurn = 360;
        
        private Transform _source;
        private float _speed;
        private float _currentRotationY;
        
        private KeyCode _turnRightButton;
        private KeyCode _turnLeftButton;
        
        private float _limitAngle;
        
        public RotatorWithButton(Transform source, float speed,KeyCode turnRightButton, KeyCode turnLeftButton ,float limitAngle = 360)
        {
            _source = source;
            _speed = speed;
            _currentRotationY = 0;
            _turnRightButton = turnRightButton;
            _turnLeftButton = turnLeftButton;
            _limitAngle = limitAngle;
        }

        public bool IsPressedTurnRightButton => Input.GetKey(_turnRightButton);
        public bool IsPressedTurnLeftButton => Input.GetKey(_turnLeftButton);

        public void Update()
        {
            if (IsPressedTurnRightButton)
                Rotate(Sides.Right);
            
            if(IsPressedTurnLeftButton)
                Rotate(Sides.Left);
        }

        private void Rotate(Sides side)
        {
            _currentRotationY += _speed * Time.deltaTime * (int)side;
            
             if(Mathf.Abs(_currentRotationY) >= FullTurn)
                 _currentRotationY = 0;
            
            if(_limitAngle > 0 && _limitAngle < FullTurn)
                _currentRotationY = Mathf.Clamp(_currentRotationY, -_limitAngle, _limitAngle);
            
            _source.rotation = Quaternion.Euler(0, _currentRotationY, 0);
        }
    }
}
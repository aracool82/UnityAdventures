using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Sail : RotateControl
    {
        [SerializeField] private Ship _ship;
        [SerializeField] float _limitAngle;

        private float _currentAngle = 0;

        protected override void Update()
        {
            float selectedCoefficient = 4.1f;

            if (Input.GetKey(KeyCode.A) && _currentAngle < _limitAngle)
            {
                _rotator.RotateLeft(Time.deltaTime);
                _currentAngle += Time.deltaTime * _rotator.RotateSpeed / selectedCoefficient; 
            }

            if (Input.GetKey(KeyCode.S) && _currentAngle > -_limitAngle)
            {
                _rotator.RotateRight(Time.deltaTime);
                _currentAngle -= Time.deltaTime * _rotator.RotateSpeed / selectedCoefficient;
            }
        }
    }
}
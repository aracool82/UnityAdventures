using UnityEngine;
using UnityEngine.Serialization;

namespace _Project20_21.SailingShip.Scripts
{
    public class ShipControl : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Transform _sailTransform;
        [SerializeField] private float _limitAngleY;
        
        private float _currentSailAngle = 0.0f;
        
        private bool PresedKeyQ => Input.GetKey(KeyCode.Q);
        private bool PresedKeyW => Input.GetKey(KeyCode.W);
        private bool PresedKeyA => Input.GetKey(KeyCode.A);
        private bool PresedKeyS => Input.GetKey(KeyCode.S);

        private float _rightLimit => _limitAngleY;
        private float _leftLimit => -_limitAngleY;

        private void Update()
        {
            // Управление поворотом корабля
            if (Input.GetKey(KeyCode.Q))
                RotateTo(transform,Directions.Left);

            if (Input.GetKey(KeyCode.W))
                RotateTo(transform,Directions.Right);

            if (PresedKeyA && _currentSailAngle < _limitAngleY)
            {
                RotateTo(_sailTransform,Directions.Left);
                _currentSailAngle += _rotationSpeed * Time.deltaTime;
            }

            if (PresedKeyS && _currentSailAngle > -_limitAngleY)
            {
                RotateTo(_sailTransform,Directions.Right);
                _currentSailAngle -= _rotationSpeed * Time.deltaTime;
            }
        }

        private void RotateTo(Transform source,Directions direction)
        {
            source.Rotate(0, (int)direction * _rotationSpeed * Time.deltaTime, 0);
        }

        private void RotateTo(Transform source, Directions direction, float limitAngleY = 0)
        {
            Vector3 currentRotation = source.rotation.eulerAngles;

            if (currentRotation.y < _leftLimit && currentRotation.y > _rightLimit && currentRotation != Vector3.zero)
                return;

            float rotationStep = _rotationSpeed * Time.deltaTime;

            Vector3 calculateNextVector = currentRotation + Vector3.up * (((int)direction) * rotationStep);

            if (limitAngleY == 0)
                source.rotation = Quaternion.Euler(calculateNextVector);
            else
            {
                if (calculateNextVector.y > _leftLimit && calculateNextVector.y < _rightLimit)
                    source.rotation = Quaternion.Euler(calculateNextVector);
                // else
                //     source.rotation = Quaternion.Euler(new Vector3(0,limitAngleY,0) );
            }
        }
    }
}
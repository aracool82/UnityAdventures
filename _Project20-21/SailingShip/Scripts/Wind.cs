using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private Ship _ship;

        [SerializeField] private float _changeDirectionTime;
        private float _time;

        private AngleLess90Condition _angleLess90Condition;
        private float _minAngle = 0;
        private float _maxAngle = 90;
        [SerializeField ,Range(0,1)]private  float _power;

        private void Awake()
        {
            _angleLess90Condition = new AngleLess90Condition(transform);
        }

        private void Update()
        {
            float _currentAngle = Vector3.Angle(transform.forward, _ship.ParusDirection);

            if (_currentAngle < _maxAngle && _currentAngle > _minAngle)
                if (_currentAngle == 0)
                    _power = 1;
                else
                    _power = _minAngle / _currentAngle;
            else
                _power = 0;

            //transform.position =
            //    new Vector3(_ship.transform.position.x, transform.position.y, _ship.transform.position.z);

            _time += Time.deltaTime;

            if (_time >= _changeDirectionTime)
            {
                _time = 0;
                //transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 180), 0));
            }
        }

        private void OnDrawGizmos()
        {
            _angleLess90Condition = new AngleLess90Condition(transform);
            Vector3 start = new Vector3(0, 1, -1);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(start, transform.forward);

            Gizmos.color = Color.green;
            Gizmos.DrawRay(start, _ship.ParusDirection);
            float angle = Vector3.Angle(transform.forward, _ship.ParusDirection);
           // Debug.Log(angle);
        }
    }
}
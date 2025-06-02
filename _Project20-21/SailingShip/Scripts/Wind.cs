using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {
<<<<<<< HEAD
        private DirectionGenerator _directionGenerator;
        private Rotator _rotator;
        
        private void Awake()
        {
            _directionGenerator = new DirectionGenerator(3, 360);
            _rotator = new Rotator(transform, 500);
=======
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
>>>>>>> 22494db7b0f19975db69bb786742f6931201eefa
        }

        private void Update()
        {
<<<<<<< HEAD
            _directionGenerator.Update(Time.deltaTime);
            _rotator.Rotation(Time.deltaTime, _directionGenerator.Direction);    
=======
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
>>>>>>> 22494db7b0f19975db69bb786742f6931201eefa
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
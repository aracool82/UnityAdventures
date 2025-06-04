using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private Sail _sail;
        
        private DirectionGenerator _directionGenerator;
        private Rotator _rotator;
        
        private float _maxAngle = 90f;

        public float Power => CalculatePower();

        private void Awake()
        {
            _directionGenerator = new DirectionGenerator(2, 360);
            _rotator = new Rotator(transform, 500);
        }

        private void Update()
        {
            _directionGenerator.Update(Time.deltaTime);
            _rotator.Rotation(_directionGenerator.Direction);
            
            Vector3 position = transform.position;
            position.x = _sail.transform.position.x;
            position.y = transform.position.y;
            position.z = _sail.transform.position.z;
            transform.position = position;
        }

        private float CalculatePower()
        {
            // float angle = Vector3.Angle(transform.forward, _sail.transform.forward);
            //
            // if (angle > _maxAngle)
            //     return 0;
            // else
            //     return 1 - angle/_maxAngle;
           
            float dotProduct = Vector3.Dot(transform.forward, _sail.transform.forward);
            
            if(dotProduct < 0)
                dotProduct = 0;
            
            return  dotProduct;
        }
    }
}
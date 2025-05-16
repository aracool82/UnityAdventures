using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Mover 
    {
        private Transform _source;
        
        public Mover(Transform source, float speed)
        {
            _source = source;

            if (IsValidFloat(speed) == false)
                speed = 0;
           
            Speed = speed;
        }
        
        public float Speed { get; private set; }

        public void MoveToDirection(Vector3 direction)
        {
            _source.Translate(direction * (Speed * Time.deltaTime), Space.World);
            _source.rotation = Quaternion.LookRotation(direction);
        }

        public void SetSpeed(float speed)
        {
            if (IsValidFloat(speed))
                Speed = speed;
            else
                Debug.LogError("Speed can't be less than 0");
        }
      
        public bool TryGetDirection(Transform target,out Vector3 direction)
        {
            if (target == null)
            {
                direction = Vector3.zero;
                Debug.Log("Target is null");
                return false;
            }
            
            direction = (target.transform.position - _source.position).normalized;
            return true;
        }

        private bool IsValidFloat(float value)
            => value >= 0;
    }
}
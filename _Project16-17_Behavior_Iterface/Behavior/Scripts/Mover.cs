using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        
        private float _minDistance = 0.1f;

        public void Move(Vector3 direction)
        {
            transform.Translate(direction * (_speed * Time.deltaTime), Space.World);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public void MoveToTarget(Vector3 target)
        {
            if(IsReachedTarget(target) == false)
                Move(GetDirection(target));
        }
        
        private bool IsReachedTarget(Vector3 target)
            => (transform.position - target).magnitude <= _minDistance;

        private Vector3 GetDirection(Vector3 target)
            => (target - transform.position).normalized;
    }
}
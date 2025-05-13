using UnityEngine;

namespace _Progect12_13.Scripts.TiltPlatform
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed;
        
        private Vector3 _direction;
        
        public void Move(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _speed);
        }
    }
}
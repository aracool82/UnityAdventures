using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Wind _wind;
        [SerializeField] private Sail _sail;
        
        //public Vector3 SailDirection => _sail.Direction;
        
        private RotatorWithButton _rotator;

        private void Awake()
        {
            _rotator = new RotatorWithButton(transform,100,KeyCode.W,KeyCode.Q);
        }

        private  void Update()
        {
            _rotator.Ratate(Vector3.up);
        }

        private void FixedUpdate()
        {
            // if (_wind.Power == 0)
            //     _rigidbody.velocity = Vector3.zero;
            // else
            //     _rigidbody.AddForce(transform.forward * _wind.Power, ForceMode.Force);
        }
    }
}
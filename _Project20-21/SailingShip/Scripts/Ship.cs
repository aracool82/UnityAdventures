using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Ship : RotateControl
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Wind _wind;

        protected override void Update()
        {
            if (Input.GetKey(KeyCode.Q))
                _rotator.RotateLeft(Time.deltaTime);

            if (Input.GetKey(KeyCode.W))
                _rotator.RotateRight(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (_wind.Power == 0)
                _rigidbody.velocity = Vector3.zero;
            else
                _rigidbody.AddForce(transform.forward * _wind.Power, ForceMode.Force);
        }
    }
}
using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private GroundDetector _groundDetector;

        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private float _moveSpeed = 5;

        private Walet _walet = new Walet();
        public int Coins => _walet.Value;

        public void Move(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _moveSpeed, ForceMode.Force);
        }

        public void Jump()
        {
            if (_groundDetector.IsGrounded == true)
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        public void AddCoin(int amount)
        {
            _walet.Add(amount);
        }
    }
}
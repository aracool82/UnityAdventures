using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class GroundDetector : MonoBehaviour
    {
        private bool _isGrounded;

        public bool IsGrounded => _isGrounded;

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Ground ball))
                _isGrounded = false;
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Ground ball))
                _isGrounded = true;
        }
    }
}
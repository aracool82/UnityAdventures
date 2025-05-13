using UnityEngine;

namespace Progec10_11
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private Rotator _rotator;
        [SerializeField] private Mover _mover;

        private bool _canMoved = true;

        public void Move(Vector3 direction)
        {
            if (_canMoved)
                _mover.Move(direction);
        }

        public void Rotate(Vector3 direction)
        {
            if (_canMoved)
                _rotator.RotationToDirection(direction);
        }

        public void Stop()
            => _canMoved = false;

        public void StartMovement()
            => _canMoved = true;
    }
}
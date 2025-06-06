using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Sail : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] float _limitAngle;
        [SerializeField] float _speed;
        
        private RotatorWithButton _rotator;
        public Vector3 Direction => transform.forward;

        private void Awake()
        {
            _rotator = new RotatorWithButton(transform, _speed, KeyCode.S, KeyCode.A, _limitAngle);
        }

        private  void Update()
        {
           _rotator.Update();
        }
    }
}
using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Sail : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] float _limitAngle;

        private float _currentAngle = 0;
        
        private RotatorWithButtonAndLimitAngle _rotator;
        public Vector3 Direction => transform.forward;

        private void Awake()
        {
            RotatorWithButtonAndLimitAngle _rotator = new RotatorWithButtonAndLimitAngle(
                transform,
                300,
                KeyCode.A,
                KeyCode.S,
                90);
            
            
        }

        private  void Update()
        {
            _rotator.Ratate(Vector3.up);
        }
    }
}
using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public abstract class RotateControl : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        
        protected Rotator _rotator;
        
        private  void Awake()
            =>_rotator = new Rotator(transform, _rotationSpeed);

        protected abstract void Update();
    }
}
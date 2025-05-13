using UnityEngine;

namespace _Progect12_13.Scripts.TiltPlatform
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        
        public void Rotate(Vector3 rotation)
        {
            transform.rotation = Quaternion.Euler(rotation * _rotationSpeed);
        }
    }
}
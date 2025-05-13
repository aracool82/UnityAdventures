using UnityEngine;

namespace _Progect12_13.Scripts.TiltPlatform
{
    public class TiltPlatform : MonoBehaviour
    {
        [SerializeField] private Rotator _rotator;

        public void Rotate(Vector3 rotation)
        {
            _rotator.Rotate(rotation);
        }
    }
}
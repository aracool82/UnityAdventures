using UnityEngine;

namespace _Progect12_13.Scripts.TiltPlatform
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Mover _mover;

        public void Move(Vector3 direction)
           => _mover.Move(direction);
    }
}
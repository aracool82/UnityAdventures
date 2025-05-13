using UnityEngine;

namespace Progec10_11
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public void Move(Vector3 direction)
            => transform.position += direction * (Time.deltaTime * _moveSpeed);
    }
}
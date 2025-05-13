using UnityEngine;

namespace Progec10_11
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float speedRotation;

        public void RotationToTarget(Vector3 target)
            => Rotate(Quaternion.LookRotation(target - transform.position));

        public void RotationToDirection(Vector3 direction)
            => Rotate(Quaternion.LookRotation(direction));

        private void Rotate(Quaternion lookRotation)
        {
            float step = speedRotation * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
    }
}
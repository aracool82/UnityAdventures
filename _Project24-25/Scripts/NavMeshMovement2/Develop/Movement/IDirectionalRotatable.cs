using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public interface IDirectionalRotatable
    {
        public Quaternion CurrentRotation { get; }
        public void SetRotationDirection(Vector3 direction);
    }
}
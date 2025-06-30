using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public interface IDirectionalRotatable
    {
        public Quaternion CurrentRotation { get; }
        public void SetRotationDirection(Vector3 direction);
    }
}
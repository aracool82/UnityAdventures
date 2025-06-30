using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public interface IDirectionalMovable
    {
        public Vector3 CurrentVelocity { get; }
        public void SetMoveDirection(Vector3 direction);
    }
}
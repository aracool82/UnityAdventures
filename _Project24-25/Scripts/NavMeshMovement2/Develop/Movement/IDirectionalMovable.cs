using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public interface IDirectionalMovable : ITransformable
    {
        public Vector3 CurrentVelocity { get; }
        public void SetMoveDirection(Vector3 direction);
    }
}
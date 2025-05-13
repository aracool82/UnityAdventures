using UnityEngine;

namespace Progec10_11
{
    public class Npc : MonoBehaviour
    {
        [SerializeField] private PointToPointMover _pointToPointMover;

        private void Start()
            => StartMovement();

        public void Stop()
            => _pointToPointMover.StopMovement();

        public void StartMovement()
            => _pointToPointMover.StartMovement();
    }
}
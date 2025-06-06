using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Mover
    {
        private Vector3 _sourcePosition;
        private RayShooter _shooter;
        private LayerMask _groundLayerMask;

        public Mover(LayerMask groundLayerMask)
        {
            _groundLayerMask = groundLayerMask;
            _shooter = new RayShooter();
        }

        public bool TryMove(Vector3 origin, Vector3 direction, Transform source)
        {
            if (_shooter.HasShootResult(origin, direction, out RaycastHit hit, _groundLayerMask) && source != null)
            {
                Vector3 offsetY = new Vector3(0, 1.5f, 0);
                source.position = hit.point + offsetY;
                return true;
            }

            return false;
        }
    }
}
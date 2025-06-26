using UnityEngine;

namespace _Project22_23.Scripts
{
    public class ClickGroundHandler
    {
        private LayerMask _groundLayerMask;

        public ClickGroundHandler(LayerMask groundLayerMask)
            => _groundLayerMask = groundLayerMask;

        public bool TryGetPoint(Vector3 origin, Vector3 direction, LayerMask mask, out Vector3 point)
        {
            Ray ray = new Ray(origin, direction);
            point = Vector3.zero;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayerMask))
            {
                point = hit.point;
                return true;
            }

            return false;
        }
    }
}
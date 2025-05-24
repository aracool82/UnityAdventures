using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Selector
    {
        private LayerMask _boxLayerMask;

        public Selector(LayerMask boxLayerMask)
        {
            _boxLayerMask = boxLayerMask;
        }

        public bool TrySelect(Ray ray, out ISelectable selectable)
        {
            selectable = null;

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _boxLayerMask) == false)
                return false;

            if (hit.collider.TryGetComponent(out selectable))
            {
                selectable.Select();
                return true;
            }

            return false;
        }
    }
}
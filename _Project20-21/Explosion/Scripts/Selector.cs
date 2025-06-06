using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Selector
    {
        private ISelectable _selectable;
        private Transform _transformSelectable;
        private LayerMask _selectebleMask;
        private RayShooter _rayShooter;

        public Selector(LayerMask selectebleMask)
        {
            _rayShooter = new RayShooter();
            _selectebleMask = selectebleMask;
        }
        
        public Transform TransformSelectable => _transformSelectable; 
        public bool HasSelecteble => _selectable != null;

        public bool Select(Vector3 origin, Vector3 direction)
        {   
            if(_rayShooter.HasShootResult(origin, direction, out RaycastHit hit, _selectebleMask))
            {
                if (hit.collider.TryGetComponent(out ISelectable selectable))
                {
                    _selectable = selectable;
                    _selectable.Select();
                    _transformSelectable = hit.transform;
                    return true;
                }
            }
            
            return false;
        }

        public void ResetSeleceble()
        {
            _transformSelectable = null;
            _selectable.Deselect();
            _selectable = null;
        }
    }
}
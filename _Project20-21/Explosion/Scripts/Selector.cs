using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Selector
    {
        private Box _box;

        public Box GetSelected()
        {
            if(IsSelected())
                return _box;
            
            Debug.Log("No box selected");
            return null;
        }
    
        public bool TrySelect(Vector3 origin, Vector3 direction)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hit) == false)
                return false;

            if (hit.collider.TryGetComponent(out Box box))
            {
                _box = box;
                _box.Select();
                return true;
            }

            return false;
        }
        
        private bool IsSelected()
            => _box != null;
    }
}
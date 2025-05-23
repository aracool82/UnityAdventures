using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Selector
    {
        public bool TrySelectGround(Vector3 origin, Vector3 direction,out Vector3 point, out Ground ground)
        {
            if (IsTach(origin, direction, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out ground))
                {
                    point = hit.point;
                    return true;
                }
            }

            point = Vector3.zero;
            ground = null;
            return false;
        }
        
        public bool TrySelect(Vector3 origin, Vector3 direction, out Box box)
        {
            if (IsTach(origin, direction, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out box))
                {
                    if(box.IsSelected == false)
                    {
                        box.Select();
                        return true;
                    }
                    
                    box.Deselect();
                    return false;
                }
            }
            
            box = null;
            return false;
        }

        public bool TryGetPoint(Vector3 origin, Vector3 direction, out Vector3 point)
        {
            if (IsTach(origin, direction, out RaycastHit hit))
            {
                point = hit.point;
                return true;
            }

            point = Vector3.zero;
            return false;
        }

        private bool IsTach(Vector3 origin, Vector3 direction, out RaycastHit hit)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out hit))
                return true;

            hit = new RaycastHit();
            return false;
        }
    }
}
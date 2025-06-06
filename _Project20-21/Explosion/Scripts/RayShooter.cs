using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class RayShooter
    {
        public bool HasShootResult(Vector3 origin, Vector3 direction,out RaycastHit raycastHit, LayerMask layerMask)
        {
            Ray ray = new Ray(origin, direction);
            raycastHit = default;
            
            if (Physics.Raycast(ray, out RaycastHit hit ,Mathf.Infinity,layerMask ) == false)
                return false;
            
            raycastHit = hit;
            return true;
        }
    }
}
using UnityEngine;
using UnityEngine.AI;

namespace _Project24_25.NavMesh2
{
    static public class NavMeshUtills
    {
        static public bool TryGetPath(Vector3 source, Vector3 target, NavMeshQueryFilter filter, NavMeshPath path)
        {
            if (NavMesh.CalculatePath(source, target, filter, path) && path.status != NavMeshPathStatus.PathInvalid)
                return true;

            return false;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    public class ClickGroundHandler
    {
        private readonly NavMeshQueryFilter Filter;

        private LayerMask _groundLayerMask;
        private NavMeshPath _path;
        private Transform _sourcePosition;

        public ClickGroundHandler(LayerMask groundLayerMask, Transform sourcePosition)
        {
            _groundLayerMask = groundLayerMask;
            _sourcePosition = sourcePosition;

            _path = new NavMeshPath();
            Filter = new NavMeshQueryFilter();
            Filter.areaMask = NavMesh.AllAreas;
            Filter.agentTypeID = 0;
        }

        public bool TryGetPath(Ray ray, out List<Vector3> path)
        {
            path = new List<Vector3>();

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayerMask))
            {
                if (CanClikGround(hit.point))
                {
                    path = GetPath();
                    return true;
                }
            }

            return false;
        }

        private bool CanClikGround(Vector3 point)
            => NavMeshUtills.TryGetPath(_sourcePosition.position, point, Filter, _path);

        private List<Vector3> GetPath()
        {
            List<Vector3> path = new List<Vector3>();
            int corners = _path.corners.Length;
            
            if (corners > 1)
                for (int i = 1; i <= corners - 1; i++)
                    path.Add(_path.corners[i]);
            else
                Debug.LogError("No correct path");
            
            return path;
        }
    }
}
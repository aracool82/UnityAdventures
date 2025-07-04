using System.Collections.Generic;
using UnityEngine;

namespace _Project22_23.Scripts
{
    public class MouseView : MonoBehaviour
    {
        private const int LeftMouseButton = 0;

        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField, Range(0, 1)] private float _visibleTime;

        private MeshRenderer _meshRenderer;
        private bool _isVisible;
        private float _timer;
        private ClickGroundHandler _clickGroundHandler;
        private Camera _camera;
        private List<Vector3> _path;
        
        private bool IsLeftMouseButtonClick => Input.GetMouseButtonDown(LeftMouseButton);

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _clickGroundHandler = new ClickGroundHandler(_groundLayerMask,transform);
            _camera = Camera.main;
            _isVisible = false;
            _path = new List<Vector3>();
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (IsLeftMouseButtonClick && _clickGroundHandler.TryGetPath(ray, out List<Vector3> path))
            {
                _path = path;
                _timer = 0;
                _isVisible = true;
                int lastIndex = path.Count - 1;
                transform.position = path[lastIndex];
            }

            if (_isVisible)
            {
                _timer += Time.deltaTime;

                if (_timer >= _visibleTime)
                {
                    _timer = 0;
                    _isVisible = false;
                }
            }

            _meshRenderer.enabled = _isVisible;
        }

        private void OnDrawGizmos()
        {
            if(Application.isPlaying)
            {
                Gizmos.color = Color.red;
                
                if(_path != null)
                    foreach (Vector3 position in _path)
                        Gizmos.DrawSphere(position, 0.2f);                        
            }
        }
    }
}
using UnityEngine;

namespace _Project22_23.Scripts
{
    public class MouseView : MonoBehaviour
    {
        private const int LeftMouseButton = 0;

        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField,Range(0,1)] private float _visibleTime;

        private MeshRenderer _meshRenderer;
        private bool _isVisible;
        private float _timer;
        private ClickGroundHandler _clickGroundHandler;
        private Camera _camera;

        private bool IsLeftMouseButtonClick => Input.GetMouseButtonDown(LeftMouseButton);
        
        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _clickGroundHandler = new ClickGroundHandler(_groundLayerMask);
            _camera = Camera.main;
            _isVisible = false;
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (IsLeftMouseButtonClick &&
                _clickGroundHandler.TryGetPoint(ray.origin, ray.direction, _groundLayerMask, out Vector3 clickPoint))
            {
                _timer = 0;
                _isVisible = true;
                transform.position = clickPoint;
            }

            if (_isVisible)
            {
                _timer += Time.deltaTime;
                
                if(_timer >= _visibleTime)
                {
                    _timer = 0;
                    _isVisible = false;
                }
            }

            _meshRenderer.enabled = _isVisible;
        }
    }
}
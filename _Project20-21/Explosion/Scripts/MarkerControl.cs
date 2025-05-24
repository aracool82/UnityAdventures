using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class MarkerControl
    {
        private const int _rightButton = 0;
        private const int _leftButton = 1;

        private Camera _camera;
        private Transform _source;
        private LayerMask _layerMask;

        public MarkerControl(Transform source, LayerMask layerMask)
        {
            _source = source;
            _layerMask = layerMask;
            _camera = Camera.main;
        }

        public Vector3 Position => _source.position;

        public void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButton(_rightButton) || Input.GetMouseButtonDown(_leftButton))
            {
                if (Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,_layerMask) == false)
                    return;

                if (hit.collider.TryGetComponent(out Ground ground))
                    _source.position = hit.point;
            }
        }
    }
}
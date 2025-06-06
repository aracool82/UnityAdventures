using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class PLayer : MonoBehaviour
    {
        [SerializeField] private LayerMask _boxLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;

        private Selector _selector;
        private Mover _mover;
        private RayShooter _rayShooter;
        
        private Camera _camera;
        private MouseHandler _mouseHandler;

        private void Awake()
        {
            _selector = new Selector(_boxLayerMask);
            _mover = new Mover(_groundLayerMask);
            _rayShooter = new RayShooter();

            _mouseHandler = new MouseHandler();
            _camera = Camera.main;
        }

        void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (_mouseHandler.IsLeftButtonClickDown)
                _selector.Select(ray.origin, ray.direction);

            if (_mouseHandler.IsLeftButtonClickUp)
                _selector.ResetSeleceble();
            
            if (_mouseHandler.IsLeftButtonClick && _selector.HasSelecteble)
                _mover.TryMove(ray.origin, ray.direction,_selector.TransformSelectable);

            if (_mouseHandler.IsRightButtonClickDown && _rayShooter.HasShootResult(ray.origin, ray.direction,out RaycastHit hit,_boxLayerMask))
                if (hit.collider.TryGetComponent(out IExploded exploded))
                    exploded.Explode();
        }
    }
}
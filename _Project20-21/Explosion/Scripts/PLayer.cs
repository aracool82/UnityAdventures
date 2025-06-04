using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class PLayer : MonoBehaviour
    {
        [SerializeField] private LayerMask _boxLayerMask;
        [SerializeField] private LayerMask _groundLayerMask;

        private RayShooter _rayShooter;
        private Mover _mover;
        private Camera _camera;
        private MouseHandler _mouseHandler;

        private ISelectable _selectable;

        private void Awake()
        {
            _rayShooter = new RayShooter();
            _mouseHandler = new MouseHandler();
            _camera = Camera.main;
        }

        void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (_mouseHandler.IsLeftButtonClickDown &&
                _rayShooter.Shoot(ray.origin, ray.direction, out RaycastHit hit, _boxLayerMask))
            {
                if (hit.collider.TryGetComponent(out ISelectable selectable))
                {
                    _selectable = selectable;
                    _selectable.Select();
                }
            }

            if (_mouseHandler.IsLeftButtonClick &&
                _rayShooter.Shoot(ray.origin, ray.direction, out hit, _groundLayerMask))
                if (IsSelected())
                    _selectable.Move(hit.point);

            if (_mouseHandler.IsLeftButtonClickUp)
            {
                if (IsSelected())
                {
                    _selectable.Deselect();
                    _selectable = null;
                }
            }

            if (_mouseHandler.IsRightButtonClickDown &&
                _rayShooter.Shoot(ray.origin, ray.direction, out hit, _boxLayerMask))
                if (hit.collider.TryGetComponent(out IExploded exploded))
                    exploded.Explode();
        }

        private bool IsSelected()
            => _selectable != null;
    }
}
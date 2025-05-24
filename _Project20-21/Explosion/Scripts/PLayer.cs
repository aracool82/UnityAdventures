using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class PLayer : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private LayerMask _boxLayerMask;

        [SerializeField] private Transform _markerTransform;

        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionPower;
        
        [SerializeField] private ParticleSystem _boomEffectPrefab;
        
        private const int _leftMouseButton = 0;
        private const int _rightMouseButton = 1;

        private Selector _selector;
        private MarkerControl _markerControl;
        private Explosion _explosion;
        
        private Camera _camera;
        private ISelectable _selectable;
       

        private void Awake()
        {
            _selector = new Selector(_boxLayerMask);
            _markerControl = new MarkerControl(_markerTransform, _groundLayerMask);
            _camera = Camera.main;
        }

        void Update()
        {
            _markerControl.Update();
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(_leftMouseButton) && _selector.TrySelect(ray, out ISelectable selectable))
                _selectable = selectable;

            if (Input.GetMouseButton(_leftMouseButton))
                if(IsSelected())
                    _selectable.Move(_markerTransform);

            if (Input.GetMouseButtonUp(_leftMouseButton))
            {
                if (IsSelected())
                {
                    _selectable.Deselect();
                    _selectable = null;
                }
            }
            
            if(Input.GetMouseButtonDown(_rightMouseButton))
                Explode(_markerControl.Position);
        }

        private bool IsSelected()
            =>_selectable != null;

        private void Explode(Vector3 position)
        {
            Explosion explosion = new Explosion(_explosionRadius, _explosionPower,_boomEffectPrefab);
            explosion.Explode(position);
        }
    }
}
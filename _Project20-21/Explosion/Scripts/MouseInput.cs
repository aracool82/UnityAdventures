using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class MouseInput : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        
        private Selector _selector;
            
        private const int _leftMouseButton = 0;
        private const int _rightMouseButton = 1;

        private ISelectable _selectableBox;
        private IExploded _explodedBox;

        private Camera _camera;
        private Box _box;

        private void Awake()
        {
            _camera = Camera.main;
            _selector = new Selector();
        }

        void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                if (_selector.TrySelect(ray.origin, ray.direction))
                {
                    _box = _selector.GetSelected();
                    _box.Move(_target);
                }
            }

            if (Input.GetMouseButtonUp(_leftMouseButton))
            {
                //_selectableBox.DropDown();
            }

            if (Input.GetMouseButtonDown(_rightMouseButton))
            {
                //_explodedBox.Explode();
            }
        }
    }
}
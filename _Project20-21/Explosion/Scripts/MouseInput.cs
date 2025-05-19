using System;
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class MouseInput : MonoBehaviour
    {
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
            
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(_leftMouseButton))
            {
                if(_selector.TrySelect(out Box box))
                    box.PickUp();
                //_selectableBox.PickUp();
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
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class PLayer : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        
        private const int _leftMouseButton = 0;
        private const int _rightMouseButton = 1;

        private Selector _selector;
        private Camera _camera;
        private Box _box;
        private List<Box> _boxes = new List<Box>(); 
        
        private bool _canMoveSelecteble = false;

        private void Awake()
        {
            _camera = Camera.main;
            _selector = new Selector();
        }

        void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(_leftMouseButton)
                && _selector.TrySelect(ray.origin, ray.direction, out Box box))
            {
                _box = box;
                //_boxes.Add(box);
                // _canMoveSelecteble = true;
            }

            if (Input.GetMouseButton(_leftMouseButton) 
                && _selector.TrySelectGround(ray.origin, ray.direction,out Vector3 point, out Ground ground))
            {
                _canMoveSelecteble = true;
                _targetTransform.position = point; 
                if (_box != null)
                {
                    _box.Move(_targetTransform);
                }
                //MoveSelecteble(_targetTransform);
            }
            
            if(Input.GetMouseButtonUp(_leftMouseButton))
            {
                _box.Deselect();
                _canMoveSelecteble = false;
            }
        }

        private void MoveSelecteble(Transform target)
        {
            foreach (Box box in _boxes)
                box.Move(target);                
        }
    }
}
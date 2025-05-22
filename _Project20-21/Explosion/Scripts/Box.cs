using System.Collections;
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Box : MonoBehaviour, ISelectable, IExploded
    {
        private Material _material;
        private Rigidbody _rigidbody;
        private Mover _mover;

        private Coroutine _coroutine;
        private Explosion _explosion;
        
        private bool _isSelected = false;
        
        public void Initialize(Mover mover)
        {
            _mover = mover;
        }

        private void Awake()
        {
            _explosion = GetComponent<Explosion>();
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponentInChildren<MeshRenderer>().material;

            if (_material != null)
                _material.color = Color.blue;
        }

        public void Select()
        {
            _isSelected = true;
            _material.color = Color.yellow;
        }

        public void Move(Transform target)
        {
            if (target == null)
            {
                Debug.LogWarning("Target is null");
                return;
            }

            if (_isSelected)
            {
                _isSelected = false;
                _material.color = Color.blue;
                _mover.MoveTo(target);
            }
        }

        public void PickUp()
        {
            Debug.Log($"Позиция {transform}");
            //_rigidbody.MovePosition(Vector3.up);
            //transform.localPosition += Vector3.up;
        }

        public void DropDown()
        {
            _rigidbody.useGravity = true;
        }

        public void Explode()
        {
            // _explosion.Explode(transform.position, _spawner.ExplodedBoxes);
        }

       
    }
}
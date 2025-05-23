using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project20_21.Explosion.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Box : MonoBehaviour, ISelectable, IExploded
    {
        private Material _material;
        private Rigidbody _rigidbody;
        private BoxCollider _boxCollider;
        private Mover _mover;
        private Coroutine _coroutine;
        private Explosion _explosion;

        public bool IsSelected { get; private set; }

        public void Initialize(Mover mover)
        {
            _mover = mover;
        }

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _explosion = GetComponent<Explosion>();
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponentInChildren<MeshRenderer>().material;

            if (_material != null)
                _material.color = Color.blue;
        }

        public void Select()
        {
            IsSelected = true;
            _material.color = Color.yellow;
            _rigidbody.useGravity = false;
            _boxCollider.isTrigger = true;
        }

        public void Deselect()
        {
            IsSelected = false;
            _material.color = Color.blue;
            _rigidbody.useGravity = true;
            _boxCollider.isTrigger = false;
        }

        public void Move(Transform target)
        {
            if (target == null)
            {
                Debug.LogWarning("Target is null");
                return;
            }

            if (IsSelected)
            {
                transform.position = target.position + Vector3.up * 2 ;
                //_mover.MoveTo(target);
                //Deselect();
            }
        }

        public void Explode()
        {
            // _explosion.Explode(transform.position, _spawner.ExplodedBoxes);
        }
    }
}
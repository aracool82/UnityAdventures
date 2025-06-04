using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Box : MonoBehaviour, ISelectable
    {
        private Material _material;
        private Rigidbody _rigidbody;
        private BoxCollider _boxCollider;
        private Mover _mover;
        private Exploder _exploder;
        private float _explosionRadius;
        private LayerMask _boxLayerMask;
        
        public bool IsSelected { get; private set; }

        public void Initialaze(Exploder exploder, float explosionRadius, LayerMask boxLayerMask)
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponentInChildren<MeshRenderer>().material;

            _exploder = exploder;
            _explosionRadius = explosionRadius;
            _boxLayerMask = boxLayerMask;
            
            _material.color = Color.blue;
            _mover = new Mover(transform);
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

        public void Move(Vector3 position)
        {
            if (IsSelected == false)
                return;

            Vector3 offsetY = position + Vector3.up * 2;
            _mover.MoveTo(offsetY);
        }

        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _boxLayerMask);
            _exploder.Explode(transform.position, _explosionRadius, colliders);
        }
    }
}
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Box : MonoBehaviour, ISelectable,IExploded
    {
        private Material _material;
        private Rigidbody _rigidbody;
        private BoxCollider _boxCollider;
        private Mover _mover;
        private Exploder _exploder;
        private float _explosionRadius;
        private LayerMask _boxLayerMask;
        
        public void Initialaze(Exploder exploder, float explosionRadius, LayerMask boxLayerMask)
        {
            _boxCollider = GetComponent<BoxCollider>();
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponentInChildren<MeshRenderer>().material;

            _exploder = exploder;
            _explosionRadius = explosionRadius;
            _boxLayerMask = boxLayerMask;
            
            _material.color = Color.blue;
        }

        public void Select()
        {
            _material.color = Color.yellow;
            _rigidbody.useGravity = false;
            _boxCollider.isTrigger = true;
        }

        public void Deselect()
        {
            _material.color = Color.blue;
            _rigidbody.useGravity = true;
            _boxCollider.isTrigger = false;
        }

        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, _explosionRadius, _boxLayerMask);
            _exploder.Explode(transform.position, _explosionRadius, colliders);
        }
    }
}
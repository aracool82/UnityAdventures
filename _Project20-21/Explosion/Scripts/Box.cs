using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Box : MonoBehaviour, ISelectable, IExploded
    {
        private Material _material;
        private Rigidbody _rigidbody;
        private BoxCollider _boxCollider;
        private Explosion _explosion;

        public bool IsSelected { get; private set; }
        public Rigidbody Rigidbody => _rigidbody;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
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

            Vector3 offsetY = Vector3.up * 2;

            if (IsSelected)
                transform.position = target.position + offsetY;
        }
    }
}
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project20_21.Explosion.Scripts
{
    public class Box : MonoBehaviour, ISelectable
    {
        private Material _material;
        private Rigidbody _rigidbody;
        private float _offsetY = 1.0f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponentInChildren<MeshRenderer>().material;

            if (_material != null)
                _material.color = Color.HSVToRGB(0f, Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        public void PickUp()
        {
            _rigidbody.useGravity = false;
            transform.position += new Vector3(0, _offsetY, 0);
        }

        public void DropDown()
        {
            _rigidbody.useGravity = true;
        }
    }
}

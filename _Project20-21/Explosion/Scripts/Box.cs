using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project20_21.Explosion.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Explosion))]
    public class Box : MonoBehaviour, ISelectable, IExploded
    {
        [SerializeField] private MouseInput _mouseInput;

        private Spawner _spawner;
        private Material _material;
        private Rigidbody _rigidbody;
        private float _offsetY = 1.0f;

        private Explosion _explosion;

        public Rigidbody Rigidbody => _rigidbody;

        public void Initialize(Spawner spawner)
        {
            //_mouseInput.Selector;
            _spawner = spawner;
        }


        private void Awake()
        {
            _explosion = GetComponent<Explosion>();
            _rigidbody = GetComponent<Rigidbody>();
            _material = GetComponentInChildren<MeshRenderer>().material;

            if (_material != null)
                _material.color = Color.HSVToRGB(0f, Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        private void OnMouseUpAsButton()
        {
            //Explode();
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
            _explosion.Explode(transform.position, _spawner.ExplodedBoxes);
        }
    }
}
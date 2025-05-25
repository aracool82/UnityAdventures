using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour
    {
        [SerializeField] private Wind _wind;
        //[SerializeField] private float _speed;

        private const float RorationSpeed = 20f;

        private Rigidbody _rigidbody;
        private Rotator _rotator;
        private Vector3 _force;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rotator = new Rotator(transform,RorationSpeed,KeyCode.W,KeyCode.Q);
            if (_rotator == null)
            {
                Debug.LogError("No Rotator attached");
                Application.Quit();
            }

        }

        private void Update()
        {
            _rotator.Update();

            //_force = _wind.Direction * _speed * Time.deltaTime;
        }

        private void FixedUpdate()
        {
            _rigidbody.AddForce(_force);
        }
    }
}
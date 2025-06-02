using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float RorationSpeed = 20f;
        [SerializeField] private Vector3 _angle;
        private Rigidbody _rigidbody;
        private Rotator _rotator;
        private Vector3 _force;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            // _rotator = new Rotator(transform, 10, -Vector3.up, 2);
        }

        private void Update()
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_angle),
                Time.deltaTime * RorationSpeed);


            if (Input.GetKeyDown(KeyCode.Alpha1))
                transform.rotation = Quaternion.identity;
        }

        private void FixedUpdate()
        {
            // _rigidbody.AddForce(_force);
        }
    }
}
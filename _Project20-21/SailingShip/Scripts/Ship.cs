using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour
    {
<<<<<<< HEAD
        [SerializeField] private float RorationSpeed = 20f;
        [SerializeField] private Vector3 _angle;
=======
        [SerializeField] private Wind _wind;
        [SerializeField] private Transform _target;

        private const float RorationSpeed = 20f;

>>>>>>> 22494db7b0f19975db69bb786742f6931201eefa
        private Rigidbody _rigidbody;
       // private Rotator _rotator;
        private Vector3 _force;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
<<<<<<< HEAD
            // _rotator = new Rotator(transform, 10, -Vector3.up, 2);
=======
            // _rotator = new Rotator(transform,RorationSpeed,KeyCode.W,KeyCode.Q);
            // if (_rotator == null)
            // {
            //     Debug.LogError("No Rotator attached");
            //     Application.Quit();
            // }

>>>>>>> 22494db7b0f19975db69bb786742f6931201eefa
        }

        public Vector3 ParusDirection => _target.forward;
        
        private void Update()
        {
<<<<<<< HEAD
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(_angle),
                Time.deltaTime * RorationSpeed);
=======
            //_rotator.Update();
>>>>>>> 22494db7b0f19975db69bb786742f6931201eefa


            if (Input.GetKeyDown(KeyCode.Alpha1))
                transform.rotation = Quaternion.identity;
        }

        private void FixedUpdate()
        {
            // _rigidbody.AddForce(_force);
        }
    }
}
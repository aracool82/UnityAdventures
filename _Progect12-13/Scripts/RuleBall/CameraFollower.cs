using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private float _distance;
        [SerializeField] private float _offsetY;

        private float _angleX = 30;
        private Vector3 _rotation;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _camera.transform.rotation = Quaternion.Euler(new Vector3(_angleX, 0, 0));
            _camera.transform.position = _ball.transform.position ;
        }

        private void Update()
        {
            Vector3 ballPosition = _ball.transform.position;
            _camera.transform.position = ballPosition +  new Vector3(0, _offsetY, _distance);
        }
    }
}
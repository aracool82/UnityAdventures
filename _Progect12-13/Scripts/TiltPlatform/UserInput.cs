using UnityEngine;

namespace _Progect12_13.Scripts.TiltPlatform
{
    public class UserInput : MonoBehaviour
    {
        private const string Vertical = "Vertical";
        private const string Horizontal = "Horizontal";

        [SerializeField] private Ball _ball;
        [SerializeField] private TiltPlatform _tiltPlatform;

        private float _vertical;
        private float _horizontal;

        private void Update()
        {
            _vertical = Input.GetAxis(Vertical);
            _horizontal = -Input.GetAxis(Horizontal);
            
            Vector3 direction = new Vector3(_vertical, 0f,_horizontal);
           
            _tiltPlatform.Rotate(direction);
            _ball.Move(new Vector3(-_horizontal, 0f, _vertical));
        }
    }
}
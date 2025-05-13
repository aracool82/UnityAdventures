using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class UserInput : MonoBehaviour
    {
        private const string AxisHorizontal = "Horizontal";
        private const string AxisVertical = "Vertical";

        [SerializeField] private Ball _ball;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _ball.Jump();

            float horisontal = Input.GetAxisRaw(AxisHorizontal);
            float vertical = Input.GetAxisRaw(AxisVertical);

            Vector3 direction = new Vector3(horisontal, 0, vertical);
            _ball.Move(direction);
        }
    }
}
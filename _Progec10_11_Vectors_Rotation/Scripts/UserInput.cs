using UnityEngine;

namespace Progec10_11
{
    public class UserInput : MonoBehaviour
    {
        private const string AxisHorizontal = "Horizontal";
        private const string AxisVertical = "Vertical";

        [SerializeField] private GameRule _gameRule;
        [SerializeField] private Hero _hero;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _gameRule.RestartGame();

            float horisontal = Input.GetAxisRaw(AxisHorizontal);
            float vertical = Input.GetAxisRaw(AxisVertical);

            Vector3 direction = new Vector3(horisontal, 0, vertical);

            if (direction != Vector3.zero)
            {
                _hero.Move(direction);
                _hero.Rotate(direction);
            }
        }
    }
}
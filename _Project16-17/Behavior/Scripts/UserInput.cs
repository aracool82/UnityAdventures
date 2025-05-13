using UnityEngine;

namespace _Project16_17.Scripts
{
    public class UserInput : MonoBehaviour
    {
        [SerializeField] private Character _character;
        
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private void Update()
        {
            float moveX = Input.GetAxisRaw(HorizontalAxis);
            float moveZ = Input.GetAxisRaw(VerticalAxis);
            Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

            if (direction != Vector3.zero)
                _character.Move(direction);
        }
    }
}
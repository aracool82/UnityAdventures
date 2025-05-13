using UnityEngine;

namespace _Project16_17.Scripts
{
    public class CharacterInput : IUpdateble
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        private IMoveble _character;

        public CharacterInput(IMoveble character)
            =>_character = character;

        public void Update()
        {
            float moveX = Input.GetAxisRaw(HorizontalAxis);
            float moveZ = Input.GetAxisRaw(VerticalAxis);
            Vector3 direction = new Vector3(moveX, 0, moveZ).normalized;

            if (direction != Vector3.zero)
                _character.Move(direction);
        }
    }
}
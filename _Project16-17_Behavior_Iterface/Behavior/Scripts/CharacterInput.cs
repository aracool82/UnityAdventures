using UnityEngine;

namespace _Project16_17.Scripts
{
    public class CharacterInput  
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";
        
        private IMoveble _character;

        public CharacterInput(IMoveble character)
            =>_character = character;

        public void Update()
        {
            Vector3 directionXZ = new Vector3(Input.GetAxisRaw(HorizontalAxis), 0, Input.GetAxisRaw(VerticalAxis)).normalized;

            if (directionXZ != Vector3.zero)
                _character.Move(directionXZ);
        }
    }
}
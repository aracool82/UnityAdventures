using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class ButtonCondition : IRoratebleCondition
    {
        private KeyCode _buttonKey;

        public ButtonCondition(KeyCode buttonKey)
        {
            _buttonKey = buttonKey;
        }

        public bool IsComplite()
        {
            if (Input.GetKey(_buttonKey))
                return true;

            return false;
        }
    }
}
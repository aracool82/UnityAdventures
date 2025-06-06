using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class RotatorWithButton : RotatorBase
    {
        protected KeyCode _turnToRightButton;
        protected KeyCode _turnToLeftButton;

        protected bool IsPressedRightTurn => Input.GetKey(_turnToRightButton);
        protected bool IsPressedLeftTurn => Input.GetKey(_turnToLeftButton);

        public RotatorWithButton(
            Transform source,
            float speed,
            KeyCode turnToRightButton,
            KeyCode turnToLeftButton) : base(source, speed)
        {
            _turnToRightButton = turnToRightButton;
            _turnToLeftButton = turnToLeftButton;
        }

        public override void Ratate(Vector3 direction)
        {
            if (IsPressedRightTurn)
                direction = Source.rotation.eulerAngles + direction;
            else if (IsPressedLeftTurn)
                direction = Source.rotation.eulerAngles - direction;
            else
                direction = Vector3.zero;

            base.Ratate(direction);
        }
    }
}
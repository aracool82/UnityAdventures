using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class RotatorWithButtonAndLimitAngle : RotatorWithButton
    {
        private float _limitAngle;

        public RotatorWithButtonAndLimitAngle(
            Transform source,
            float speed,
            KeyCode turnToRightButton,
            KeyCode turnToLeftButton,
            float limitAngle) : base(source, speed, turnToRightButton, turnToLeftButton)
        {
            _limitAngle = limitAngle;
        }

        public override void Ratate(Vector3 direction)
        {
            if (Vector3.Angle(Source.forward, Vector3.forward) < _limitAngle)
                base.Ratate(direction);
        }
    }
}
using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class RotatorBase
    {
        protected Transform Source;
        protected float Speed;

        public RotatorBase(Transform source, float speed)
        {
            Source = source;
            Speed = speed;
        }

        public float RotateSpeed => Speed;

        public virtual void Ratate(Vector3 direction)
        {
            if(direction == Vector3.zero)
                return;
            
            Quaternion toRotation = Quaternion.Euler(direction);
            Quaternion fromRotation = Source.rotation;
            Source.rotation = Quaternion.RotateTowards(fromRotation, toRotation,Speed * Time.deltaTime );
        }
    }
}
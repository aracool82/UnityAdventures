using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public interface ISelectable
    {
        public void Select();
        public void Deselect();
        public void Move(Transform target);
    }
}
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public interface ISelectable : IMoveble, IExploded
    {
        public void Select();
        public void Deselect();
    }
}
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class MouseHandler
    {
        private const int LeftButton = 0;
        private const int RightButton = 1;

        public bool IsLeftButtonClickDown => Input.GetMouseButtonDown(LeftButton);
        public bool IsLeftButtonClickUp => Input.GetMouseButtonUp(LeftButton);
        public bool IsLeftButtonClick => Input.GetMouseButton(LeftButton);
        
        public bool IsRightButtonClickDown => Input.GetMouseButtonDown(RightButton);
    }
}
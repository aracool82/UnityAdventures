using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class WithArrowPlayerController : Controller
    {
        private Character _character;

        public WithArrowPlayerController(Character character)
           => _character = character;

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            _character.SetMoveDirection(direction);
            _character.SetRotationDirection(direction);
        }
    }
}
using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class PlayerDirectionalMovableController : Controller
    {
        private IDirectionalMovable _movable;

        public PlayerDirectionalMovableController(IDirectionalMovable movable)
            => _movable = movable;

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            _movable.SetMoveDirection(direction);
        }
    }
}
using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class PlayerDirectionalRotatableController:Controller
    {
        private IDirectionalRotatable _rotatable;

        public PlayerDirectionalRotatableController(IDirectionalRotatable rotatable)
            =>_rotatable = rotatable;


        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            _rotatable.SetRotationDirection(direction);
        }
    }
}
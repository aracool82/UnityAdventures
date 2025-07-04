using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class AlongMovableVelocityRotatableController : Controller
    {
        private IDirectionalMovable _movable;
        private IDirectionalRotatable _rotatable;

        public AlongMovableVelocityRotatableController(IDirectionalMovable movable, IDirectionalRotatable rotatable)
        {
            _movable = movable;
            _rotatable = rotatable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (_movable.CurrentVelocity != Vector3.zero)
                _rotatable.SetRotationDirection(_movable.CurrentVelocity);
        }
    }
}
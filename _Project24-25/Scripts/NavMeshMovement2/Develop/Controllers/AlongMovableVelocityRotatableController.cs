using UnityEngine;

namespace _Project24_25.NavMesh2
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
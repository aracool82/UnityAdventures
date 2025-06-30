using UnityEngine;
/*
namespace _Project22_23.Scripts
{
    public class CharacterMovementController : Controller
    {
        private const int LeftMouseButton = 0;
        
        private Character _character;
        private ClickGroundHandler _clickGroundHandler;
        private LayerMask _groundLayerMask;
        private Camera _camera;
        
        public CharacterMovementController(Character character,LayerMask groundLayerMask)
        {
            _character = character;
            _groundLayerMask = groundLayerMask;
            _clickGroundHandler = new ClickGroundHandler(groundLayerMask);
            _camera = Camera.main;
        }

        private bool IsPressedLeftMouseButton()=> Input.GetMouseButtonDown(LeftMouseButton);
        
        protected override void UpdateLogic(float deltaTime)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (IsPressedLeftMouseButton() &&
                _clickGroundHandler.TryGetPoint(ray.origin, ray.direction, _groundLayerMask, out Vector3 endPoint))
                if(NavMeshUtills.TryGetPath(_character.Position,endPoint,Filter,Path))
                    _character.SetPath(Path);
        }
    }
}
*/
using UnityEngine;
using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    public class PlayerController : Controller
    {
        private const int LeftMouseButton = 0;
        
        private Player _player;
        private ClickGroundHandler _clickGroundHandler;
        private LayerMask _groundLayerMask;
        private Camera _camera;
        
        public PlayerController(Player player,LayerMask groundLayerMask)
        {
            _player = player;
            _groundLayerMask = groundLayerMask;
            _clickGroundHandler = new ClickGroundHandler(groundLayerMask);
            _camera = Camera.main;
        }

        private bool IsPressedLeftMouseButton()=> Input.GetMouseButtonDown(LeftMouseButton);
        
        protected override void ApdateLogic(float deltaTime)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (IsPressedLeftMouseButton() &&
                _clickGroundHandler.TryGetPoint(ray.origin, ray.direction, _groundLayerMask, out Vector3 endPoint))
                if(NavMeshUtills.TryGetPath(_player.Position,endPoint,Filter,Path))
                    _player.SetPath(Path);
        }
    }
}
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace _Project24_25.NavMesh2
{
    public class AgentCharacterController : Controller
    {
        private const int LeftMouseButton = 0;

        private AgentCharacter _character;
        private Camera _camera;
        private LayerMask _groundLayer;
        private NavMeshPath _path;

        public AgentCharacterController(AgentCharacter character, LayerMask groundLayer)
        {
            _character = character;
            _groundLayer = groundLayer;
            _camera = Camera.main;
            _path = new NavMeshPath();
        }

        private bool IsPressedLeftMouseButton => Input.GetMouseButtonDown(LeftMouseButton);
        private bool IsUiClicked => EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
        
        protected override void UpdateLogic(float deltaTime)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (IsUiClicked && _character == null || _character.IsAlive == false)
                return;

            if (IsPressedLeftMouseButton && Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _groundLayer))
                if (_character.TryGetPath(hit.point, _path))
                    _character.SetDestination(hit.point);

            if (_character.IsOnNavMeshLink(out OffMeshLinkData data))
                _character.SetRotationDirection((data.endPos - data.startPos).normalized);
            else
                _character.SetRotationDirection(_character.CurrentVelocity.normalized);
        }
    }
}
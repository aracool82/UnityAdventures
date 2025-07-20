using UnityEngine;
using UnityEngine.AI;

namespace _Project24_25.NavMesh2
{
    public class CharacterAgent : MonoBehaviour
    {
        private const int LeftMouseButton = 0;
        
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _rotationSpeed = 900f;
        
        private DirectionRotator _directionRotator;
        private NavMeshAgent _agent;
        private NavMeshPath _path;
        private Camera _camera;
        
        private bool IsPressedLeftMouseButton => Input.GetMouseButtonDown(LeftMouseButton);
        
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _directionRotator = new DirectionRotator(transform,_rotationSpeed);
            _camera = Camera.main;
            _path = new NavMeshPath();
            
            _agent.updateRotation = false;
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if(IsPressedLeftMouseButton && 
               Physics.Raycast(ray,out RaycastHit hit,Mathf.Infinity,_groundLayer))
                if(_agent.CalculatePath(hit.point, _path))
                    _agent.SetDestination(hit.point);
            
            _directionRotator.SetDirection(_agent.desiredVelocity.normalized);
            _directionRotator.Update(Time.deltaTime);
        }
    }
}
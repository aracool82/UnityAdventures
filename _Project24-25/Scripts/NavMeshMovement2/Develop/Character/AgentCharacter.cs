using UnityEngine;
using UnityEngine.AI;

namespace _Project24_25.NavMesh2
{
    public class AgentCharacter : MonoBehaviour
    {
        private const int LeftMouseButton = 0;

        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _rotationSpeed = 900f;
        [SerializeField] private float _moveSpeed = 6f;

        private DirectionRotator _rotator;
        private AgentMover _agentMover;

        private NavMeshAgent _agent;

        public Vector3 CurrentVelocity => _agentMover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _rotator = new DirectionRotator(transform, _rotationSpeed);
            _agentMover = new AgentMover(_agent, _moveSpeed);
            
            _agent.updateRotation = false;
        }

        private void Update()
        {
            _rotator.Update(Time.deltaTime);
            
            if(_agent.isOnOffMeshLink)
            {
                Debug.Log($"In the Mesh Link go jamp : {_agent.currentOffMeshLinkData}");
                OffMeshLinkData data = _agent.currentOffMeshLinkData;

            }
        }

        public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
            => NavMeshUtills.TryGetPath(_agent, targetPosition, pathToTarget);
        
        public void SetDestination(Vector3 position)
            => _agent.SetDestination(position);

        public void SetRotationDirection(Vector3 direction)
            => _rotator.SetDirection(direction);

        public void StopMove()
            => _agentMover.Stop();

        public void ResumeMove()
            => _agentMover.Resume();
    }
}
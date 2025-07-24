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
        [SerializeField] private float _jumpSpeed = 5f;
        [SerializeField] private AnimationCurve _jumpCurve;
        
        private DirectionRotator _rotator;
        private AgentMover _mover;
        private AgentJumper _jumper;

        private NavMeshAgent _agent;

        public Vector3 CurrentVelocity => _mover.CurrentVelocity;
        public Quaternion CurrentRotation => _rotator.CurrentRotation;
        public bool InJumpProcess => _jumper.InProcessJump;
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();

            _rotator = new DirectionRotator(transform, _rotationSpeed);
            _mover = new AgentMover(_agent, _moveSpeed);
            _jumper = new AgentJumper(_agent, _jumpSpeed,this,_jumpCurve);
            _agent.updateRotation = false;
        }

        private void Update()
        {
            _rotator.Update(Time.deltaTime);
            
            if(_agent.isOnOffMeshLink)
            {
                Debug.Log($"In the Mesh Link go jamp : {_agent.currentOffMeshLinkData}");
                OffMeshLinkData data = _agent.currentOffMeshLinkData;
                _jumper.Jump(data);
            }
        }

        public void Jamp(OffMeshLinkData data)
            =>_jumper.Jump(data);

        public bool IsOnNavMeshLink(out OffMeshLinkData data)
        {
            if (_agent.isOnOffMeshLink)
            {
                data = _agent.currentOffMeshLinkData;
                return true;
            }
            
            data = default(OffMeshLinkData);
            return false;
        }

        public bool TryGetPath(Vector3 targetPosition, NavMeshPath pathToTarget)
            => NavMeshUtills.TryGetPath(_agent, targetPosition, pathToTarget);
        
        public void SetDestination(Vector3 position)
            => _agent.SetDestination(position);

        public void SetRotationDirection(Vector3 direction)
            => _rotator.SetDirection(direction);

        public void StopMove()
            => _mover.Stop();

        public void ResumeMove()
            => _mover.Resume();
    }
}
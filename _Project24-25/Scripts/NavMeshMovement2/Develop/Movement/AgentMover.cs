using UnityEngine;
using UnityEngine.AI;

namespace _Project24_25.NavMesh2
{
    public class AgentMover
    {
        private NavMeshAgent _agent;
        private float _speed;

        public AgentMover(NavMeshAgent agent, float speed)
        {
            _agent = agent;
            _speed = speed;
            _agent.acceleration = 999;
        }

        public Vector3 CurrentVelocity => _agent.desiredVelocity;

        public void SetDestination(Vector3 position)
            =>_agent.SetDestination(position);
        
        public void Stop ()
        => _agent.isStopped = true;
        
        public void Resume ()
            => _agent.isStopped = false;
    }
}
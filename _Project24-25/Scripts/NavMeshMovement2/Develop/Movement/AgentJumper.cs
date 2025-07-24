using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace _Project24_25.NavMesh2
{
    public class AgentJumper
    {
        private NavMeshAgent _agent;
        private float _jumpSpeed;
        private MonoBehaviour _coroutineRunner;
        private Coroutine _jumpCoroutine;
        private AnimationCurve _jumpCurve;
        public AgentJumper(NavMeshAgent agent, float jumpSpeed, MonoBehaviour coroutineRunner, AnimationCurve jumpCurve)
        {
            _agent = agent;
            _jumpSpeed = jumpSpeed;
            _coroutineRunner = coroutineRunner;
            _jumpCurve = jumpCurve;
        }

        public bool InProcessJump => _jumpCoroutine != null;

        public void Jump(OffMeshLinkData linkData)
        {
            if (InProcessJump)
                return;

            _jumpCoroutine = _coroutineRunner.StartCoroutine(JumpProcess(linkData));
        }

        private IEnumerator JumpProcess(OffMeshLinkData linkData)
        {
            Vector3 startPosition = linkData.startPos;
            Vector3 endPosition = linkData.endPos;

            float duration = Vector3.Distance(startPosition, endPosition) / _jumpSpeed;
            float progress = 0;

            while (progress < duration)
            {
                float yOffset = _jumpCurve.Evaluate(progress/duration);
                
                _agent.transform.position = Vector3.Lerp(startPosition, endPosition, progress / duration) + Vector3.up * yOffset;
                progress += Time.deltaTime;
                yield return null;
            }

            _agent.CompleteOffMeshLink();
            _jumpCoroutine = null;
        }
    }
}
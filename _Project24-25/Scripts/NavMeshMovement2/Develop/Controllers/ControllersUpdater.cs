using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class ControllersUpdater : MonoBehaviour
    {
        [SerializeField] private AgentCharacter _character;
        [SerializeField] private LayerMask _groundLayerMask;

        private BehaviourSwitcherController _behaviourSwitcher;
        private Controller _agentController;

        private void Awake()
        {
            _agentController = new AgentCharacterController(_character, _groundLayerMask);
            _agentController.Enable();
        }

        private void Update()
        {
            _agentController.Update(Time.deltaTime);
        }
    }
}
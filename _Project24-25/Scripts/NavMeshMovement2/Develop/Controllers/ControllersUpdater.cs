using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class ControllersUpdater : MonoBehaviour
    {
        [SerializeField] private AgentCharacter _character;
        [SerializeField] private Transform _marker;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _timeToChangeController = 2f;
        [SerializeField] private float _patrolRadius = 5f;

        private BehaviourSwitcherController _behaviourSwitcher;
        private Controller _agentController;

        private void Awake()
        {
            //ClickGroundHandler clickGroundHandler = new ClickGroundHandler(_groundLayerMask,_character.transform);

            // CompositeController patrolController = new CompositeController(
            //     new PatrolController(_character,_marker,_timeToChangeController,_patrolRadius),
            //     new AlongMovableVelocityRotatableController(_character,_character));


            _agentController = new AgentCharacterController(_character, _groundLayerMask);

            _agentController.Enable();

            // _behaviourSwitcher = new BehaviourSwitcherController(playerController,patrolController,_timeToChangeController);
            // _behaviourSwitcher.Enable();

            //_character.gameObject.SetActive(false);
            //gameObject.SetActive(false);
        }

        private void Update()
        {
            _agentController.Update(Time.deltaTime);
        }
    }
}
using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class ControllersUpdater : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _timeToChangeController = 2f;
        [SerializeField] private float _patrolRadius = 5f;
        
        private BehaviourSwitcherController _behaviourSwitcher;
        
        private void Awake()
        {
            ClickGroundHandler clickGroundHandler = new ClickGroundHandler(_groundLayerMask,_character.transform);
            
            CompositeController patrolController = new CompositeController(
                new PatrolController(_character,_timeToChangeController,_patrolRadius),
                new AlongMovableVelocityRotatableController(_character,_character));

            
            CompositeController playerController = new CompositeController(
                new WithMousePlayerController(_character, clickGroundHandler),
                new AlongMovableVelocityRotatableController(_character,_character));
            
            _behaviourSwitcher = new BehaviourSwitcherController(playerController,patrolController,_timeToChangeController);
            _behaviourSwitcher.Enable();
        }

        private void Update()
        {
            _behaviourSwitcher.Update(Time.deltaTime);
        }
    }
}

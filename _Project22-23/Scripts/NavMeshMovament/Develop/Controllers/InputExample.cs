using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class InputExample : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _timeToChangeController;

        private float _timer;

        private CompositeController _playerController;
        private CompositeController _playerPatrolController;
        
        private Controller _defaultController;

        private void Awake()
        {
            ClickGroundHandler clickGroundHandler = new ClickGroundHandler(_groundLayerMask,_character.transform);
            
            _playerPatrolController = new CompositeController(
                new PatrolPlayerController(_character,2,8),
                new AlongMovableVelocityRotatableController(_character,_character));
            
            _playerPatrolController.Enable();
            
            _playerController = new CompositeController(
                new WithMousePlayerController(_character, clickGroundHandler),
                new AlongMovableVelocityRotatableController(_character,_character));
            
            _playerController.Enable();
            
            _defaultController = _playerController;
            _defaultController.Enable();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _timer = 0;
                _playerController.Enable();
                _playerPatrolController.Disable();
                _defaultController = _playerController;
            }
            
            _timer += Time.deltaTime;
            
            if (_timer >= _timeToChangeController)
            {
                _timer = 0;
                _playerController.Disable();
                _playerPatrolController.Enable();
                _defaultController = _playerPatrolController;
            }
            
            _defaultController.Update(Time.deltaTime);
        }
    }
}

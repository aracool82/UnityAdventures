using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class InputExample : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private LayerMask _groundLayerMask;

        private Controller _playerController;

        private void Awake()
        {
            ClickGroundHandler clickGroundHandler = new ClickGroundHandler(_groundLayerMask,_character.transform);
            
            // _playerController = new CompositeController(
            //     new WithMousePlayerController(_character, clickGroundHandler),
            //     new AlongMovableVelocityRotatableController(_character,_character));

            _playerController = new CompositeController(new WithMousePlayerController(_character, clickGroundHandler));
            
            _playerController.Enable();
        }

        private void Update()
        {
            _playerController.Update(Time.deltaTime);
        }
    }
}
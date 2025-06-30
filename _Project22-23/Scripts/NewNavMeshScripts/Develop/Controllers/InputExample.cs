using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class InputExample : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Tower _tower;

        private Controller _playerController;
        private Controller _towerController;

        private void Awake()
        {
            // _playerController = new CompositeController(
            //     new PlayerDirectionalMovableController(_character),
            //     new PlayerDirectionalRotatableController(_character));

            _playerController = new CompositeController(
                new RandomAiDiretionalMovableController(2,_character),
                new AlongMovableVelocityRotatableController(_character,_character));
            
            _playerController.Enable();

            _towerController = new PlayerDirectionalRotatableController(_tower);
            _towerController.Enable();
        }

        private void Update()
        {
            _towerController.Update(Time.deltaTime);
            _playerController.Update(Time.deltaTime);
        }
    }
}
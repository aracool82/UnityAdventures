using UnityEngine;

namespace _Project22_23.Scripts
{
    public class SwicherMovement : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private LayerMask _groundLayerMask;
        [SerializeField] private float _forAiRadius = 5;
        
        private Controller _movementController;
        
        private float _timer;
        private float _waitTime = 4f;

        private void Awake()
            => SetDefaultController();

        private void Update()
        {
            if (character.IsMoving == false)
            {
                _timer += Time.deltaTime;
                
                if(_timer >= _waitTime)
                {
                    _timer = 0;
                    SetAIController();
                }
            }
            else
            {
                _timer = 0;
                SetDefaultController();
            }

            _movementController.Update(Time.deltaTime);
        }

        private void SetDefaultController()
        {
            _movementController = new CharacterMovementController(character, _groundLayerMask);
            _movementController.Enable();
            Debug.Log("Player Enabled");
        }
        
        private void SetAIController()
        {
            _movementController = new PatrolController(character, _forAiRadius);
            _movementController.Enable();
            Debug.Log("Ai Enabled");
        }
    }
}
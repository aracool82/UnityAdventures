using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class BehaviourSwitcherController : Controller
    {
        private const int LeftMouseButton = 0;

        private Controller _currentController;
        private CompositeController _playerController;
        private CompositeController _patrolController;
        
        private float _timer;
        private float _timeToChangeController;

        public BehaviourSwitcherController(CompositeController playerController, CompositeController patrolController, float timeToChangeController)
        {
            _playerController = playerController;
            _patrolController = patrolController;
            
            _timeToChangeController = timeToChangeController;
            
            _patrolController.Enable();
            _playerController.Disable();
            
            _currentController = patrolController;
        }

        private bool IsPresedLeftMouseButton => Input.GetMouseButton(LeftMouseButton);

        protected override void UpdateLogic(float deltaTime)
        {
            if (IsPresedLeftMouseButton)
            {
                _timer = 0;
                _playerController.Enable();
                _patrolController.Disable();
                _currentController = _playerController;
            }

            _timer += Time.deltaTime;

            if (_timer >= _timeToChangeController)
            {
                _timer = 0;
                _playerController.Disable();
                _patrolController.Enable();
                _currentController = _patrolController;
            }

            _currentController.Update(Time.deltaTime);
        }
    }
}
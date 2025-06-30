using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class RandomAiDiretionalMovableController : Controller
    {
        private IDirectionalMovable _movable;
        private float _timeToChangeDirection;
        private float _timer;

        public RandomAiDiretionalMovableController(float timeToChangeDirection, IDirectionalMovable movable)
        {
            _timeToChangeDirection = timeToChangeDirection;
            _movable = movable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer >= _timeToChangeDirection)
            {
                Vector3 direction =  new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
                _timer = 0;
                
                _movable.SetMoveDirection(direction);
            }
        }
    }
}
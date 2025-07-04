using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class RandomAiCharacterController : Controller
    {
        private Character _character;
        private float _timeToChangeDirection;
        private float _timer;

        public RandomAiCharacterController(float timeToChangeDirection, Character character)
        {
            _timeToChangeDirection = timeToChangeDirection;
            _character = character;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer >= _timeToChangeDirection)
            {
                Vector3 direction =  new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
                _timer = 0;
                
                _character.SetMoveDirection(direction);
                _character.SetRotationDirection(direction);
            }
        }
    }
}
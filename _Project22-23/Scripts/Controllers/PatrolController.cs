using UnityEngine;

namespace _Project22_23.Scripts
{
    public class PatrolController : Controller
    {
        private Character _character;
        private float _radius;
        private float _timer;
        private float _waitTimerToChangePath;

        public PatrolController(Character character, float radius)
        {
            _character = character;
            _radius = radius;
            _waitTimerToChangePath = 2f;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _timer += deltaTime;
            
            if (_timer >= _waitTimerToChangePath)
            {
                _timer = 0;
                Vector3 point;
                int tryCouter = 10;

                do
                {
                    tryCouter--;
                    point = GetRandomPointInRadius();
                } while (NavMeshUtills.TryGetPath(_character.Position, point, Filter, Path) == false && tryCouter != 0);

                if (tryCouter == 0)
                    Debug.Log("No path found.You can increase tryCouter");
                else
                    _character.SetPath(Path);
            }
        }

        private Vector3 GetRandomPointInRadius()
            => _character.Position +
               new Vector3(Random.Range(-_radius, _radius), 1, Random.Range(-_radius, _radius));
    }
}
using UnityEngine;

namespace _Project22_23.Scripts
{
    public class AIController : Controller
    {
        private Player _player;
        private float _radius;
        private float _timer;
        private float _waitTimerToChangePath;

        public AIController(Player player, float radius)
        {
            _player = player;
            _radius = radius;
            _waitTimerToChangePath = 2f;
        }

        protected override void ApdateLogic(float deltaTime)
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
                } while (NavMeshUtills.TryGetPath(_player.Position, point, Filter, Path) == false && tryCouter != 0);

                if (tryCouter == 0)
                    Debug.Log("No path found.You can increase tryCouter");
                else
                    _player.SetPath(Path);
            }
        }

        private Vector3 GetRandomPointInRadius()
            => _player.Position +
               new Vector3(Random.Range(-_radius, _radius), 1, Random.Range(-_radius, _radius));
    }
}
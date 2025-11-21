using UnityEngine;

namespace _Project31.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private GameCycle _gameCycle;

        private void Awake()
        {
            _gameCycle = new GameCycle(this);
            _gameCycle.Launch();
        }

        private void Update()
        {
            _gameCycle.Update(Time.deltaTime);
        }
    }
}
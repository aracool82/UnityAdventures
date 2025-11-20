using System;

namespace _Project31.Scripts
{
    public class GameMode
    {
        public event Action<string> Win;
        public event Action<string> Defeat;
        
        private Condition _conditionWin;
        private Condition _conditionDefeat;
        private bool _isRunning;
        
        private EnemySpawner _spawner;

        public GameMode(EnemySpawner spawner)
        {
            _spawner = spawner;
        }

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;
            
            if(_conditionWin.IsCompleted)
            {
                Win?.Invoke(_conditionWin.Description);
                Stop();
                return;
            }
            
            if(_conditionDefeat.IsCompleted)
            {
                Defeat?.Invoke(_conditionDefeat.Description);
                Stop();
            }
        }

        public void SetConditions(Condition conditionWin, Condition conditionDefeat)
        {
            _conditionWin = conditionWin;
            _conditionDefeat = conditionDefeat;
        }

        public void Start()
        {
           _isRunning = true;
           _spawner.Start();
        }

        public void Stop()
        {
            _isRunning = false;
            _spawner.Stop();
        }
    }
}
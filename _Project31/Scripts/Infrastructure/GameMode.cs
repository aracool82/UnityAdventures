using System;

namespace _Project31.Scripts
{
    public class GameMode
    {
        public event Action<string> Win;
        public event Action<string> Defeat;
        
        private ICondition _conditionWin;
        private ICondition _conditionDefeat;
        private bool _isRunning;
        
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

        public void SetConditions(ICondition conditionWin, ICondition conditionDefeat)
        {
            _conditionWin = conditionWin;
            _conditionDefeat = conditionDefeat;
        }

        public void Start()
        {
           _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
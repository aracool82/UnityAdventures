using _Project29_30.Scripts.ReactiveGeneric_Health;

namespace _Project29_30.Scripts.Task1.ReactiveTimer
{
    public class Timer
    {
        private ReactiveVariable<float> _maxTime;
        private ReactiveVariable<float> _currentTime;
        
        private ReactiveVariable<bool> _isFinished;
        private ReactiveVariable<bool> _isStarted;
        
        private bool _isRunningTime;

        public Timer(float maxTime,float currentTime = 0)
        {
            if(currentTime > maxTime)
                currentTime = maxTime;
            
            _maxTime = new ReactiveVariable<float>(maxTime);
            _currentTime = new ReactiveVariable<float>(currentTime);
            
            _isFinished = new ReactiveVariable<bool>(false);
            _isStarted = new ReactiveVariable<bool>(false);
            
            _isRunningTime = false;
        }
        
        public IReadOnlyVariable<float> MaxTime => _maxTime;
        public IReadOnlyVariable<float> CurrentTime => _currentTime;
        public IReadOnlyVariable<bool> IsStarted => _isStarted; 
        public IReadOnlyVariable<bool> IsFinished => _isFinished;
        
        public void Update(float deltaTime)
        {
            if(_isRunningTime == false)
                return;
            
            _currentTime.Value += deltaTime;
            
            if(_currentTime.Value >= _maxTime.Value)
                Stop();
        }

        public void Stop()
        {
            _isRunningTime = false;
            _isFinished.Value = true;
        }
        
        public void Resume()
            =>_isRunningTime = true;

        public void Restart()
            => Start();
        
        public void Start()
        {
            _isRunningTime = true;
            _currentTime.Value = 0;
            _isFinished.Value = false;
            
            _isStarted.Value = true;
            _isStarted.Value = false;
        }
    }
}
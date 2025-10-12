using System;

namespace _Project27_28.Scripts.Task2
{
    public class TimerService : IUpdateble
    {
        public event Action Changed;

        private float _elapsedTime;
        private bool _isRunning;
        private float _tick;
        private float _time;

        public TimerService(float duration)
        {
            if (duration < 1)
                duration = 1;

            Duration = duration;
            Value = 0;
            _isRunning = false;
            _elapsedTime = 0;
            _tick = 1;
        }

        private bool IsTicking => _time >= _tick;
        
        public float Value { get; private set; }
        public float Duration { get; }

        public void UpdateLogic(float deltaTime)
        {
            if (_isRunning == false)
                return;

            _elapsedTime += deltaTime;
            _time += deltaTime;

            if (IsTicking)
            {
                Value++;
                _time = 0;
                Changed?.Invoke();
            }

            if (Value >= Duration)
                Stop();
        }

        public void Start()
            => _isRunning = true;

        public void Stop()
            => _isRunning = false;

        public void Reset()
        {
            _time = 0;
            _elapsedTime = 0;
            Value = 0;
            Changed?.Invoke();
        }
    }
}
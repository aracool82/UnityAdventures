using System;
using UnityEngine;

namespace _Project27_28.Scripts.Task2
{
    public class Timer : MonoBehaviour
    {
        public event Action Changed
        {
            add => _timerService.Changed += value;
            remove => _timerService.Changed -= value;
        }

        private TimerService _timerService;

        public void Initialize(TimerService timerService)
        {
            _timerService = timerService;
        }

        public void UpdateLogic(float deltaTime)
            =>_timerService.UpdateLogic(deltaTime);

        public float Value => _timerService.Value;
        public float Duration => _timerService.Duration;

        public void Start()
            => _timerService.Start();

        public void Stop()
            => _timerService.Stop();


        public void Reset()
            => _timerService.Reset();
    }
}
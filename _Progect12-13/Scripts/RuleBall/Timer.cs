using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float _time;

        private float _timeCounter;
        private bool _isRunning;

        public bool IsOverTime => _timeCounter >= _time;

        private void Update()
        {
            if (_isRunning == false)
                return;

            _timeCounter += Time.deltaTime;
            float time = _time - _timeCounter;
            Debug.Log($"Time - {time.ToString("0")}");

            if (_timeCounter >= _time)
                _isRunning = false;
        }

        public void StopTimer()
            => _isRunning = false;

        public void StartCounting()
        {
            ResetTimer();
            _isRunning = true;
        }
        
        private void ResetTimer()
            => _timeCounter = 0;
    }
}
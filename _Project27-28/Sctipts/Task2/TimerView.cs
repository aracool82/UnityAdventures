using TMPro;
using UnityEngine;

namespace _Project27_28.Scripts.Task2
{
    public class TimerView : MonoBehaviour
    {
        private const string Text = "Time : ";

        [SerializeField] private TMP_Text _text;

        private TimerService _timerService;

        public void Initialize(TimerService timerService)
        {
            _timerService = timerService;
            _timerService.Changed += OnChange;
        }

        private void OnDisable()
            => _timerService.Changed -= OnChange;

        public void StartService()
            => _timerService.Start();
        
        public void StopService()
            => _timerService.Stop();
        
        public void  ResetService()
            => _timerService.Reset();

        private void OnChange()
            => _text.text = $"{Text} {_timerService.Value}";
    }
}
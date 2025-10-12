using UnityEngine;
using UnityEngine.UI;

namespace _Project27_28.Scripts.Task2
{
    public class SliderBarView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        
        private TimerService _timerService;

        public void Initialize(TimerService timerService)
        {
            _timerService = timerService;
            _timerService.Changed += OnChange;
        }

        private void OnDisable()
        {
            _timerService.Changed += OnChange;
        }

        private void OnChange()
        {
            _slider.value = _timerService.Value / _timerService.Duration;
        }
    }
}
using UnityEngine;
using UnityEngine.UI;

namespace _Project27_28.Scripts.Task2
{
    public class SliderBarView : MonoBehaviour
    {
        [SerializeField] private Timer _timer;
        [SerializeField] private Slider _slider;

        public void Initialize(Timer timer)
        {
            _timer = timer;
            _timer.Changed += OnChange;
        }

        private void OnDisable()
        {
            _timer.Changed += OnChange;
        }

        private void OnChange()
        {
            _slider.value = _timer.Value / _timer.Duration;
        }
    }
}
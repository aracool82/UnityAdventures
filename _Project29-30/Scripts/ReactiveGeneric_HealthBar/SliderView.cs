using UnityEngine;
using UnityEngine.UI;

namespace _Project29_30.Scripts.ReactiveGeneric_Health
{
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private IReadOnlyVariable<float> _max;
        private IReadOnlyVariable<float> _current;

        public void Initialize(IReadOnlyVariable<float> max, IReadOnlyVariable<float> current)
        {
            _max = max;
            _current = current;

            _current.Changed += OnCurrentChanged;
            _max.Changed += OnMaxChanged;
            
            UpdateValue(_current.Value, _max.Value);
        }

        private void OnDestroy()
        {
            _max.Changed -= OnCurrentChanged;
            _current.Changed -= OnCurrentChanged;
        }
        private void OnMaxChanged(float oldValue, float newValue)
            => UpdateValue(_current.Value,newValue);

        private void OnCurrentChanged(float oldValue, float newValue)
            => UpdateValue(newValue,_max.Value);

        private void UpdateValue(float currentValue, float maxValue)
            => _slider.value = currentValue / maxValue;

    }
}
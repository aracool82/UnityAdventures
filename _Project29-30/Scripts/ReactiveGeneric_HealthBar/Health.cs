using UnityEngine;

namespace _Project29_30.Scripts.ReactiveGeneric_Health
{
    public class Health
    {
        private ReactiveVariable<float> _max;
        private ReactiveVariable<float> _current;
        
        public Health(float max, float current)
        {
            _max = new ReactiveVariable<float>(max);
            _current = new ReactiveVariable<float>(current);
        }

        public IReadOnlyVariable<float> Max => _max;
        public IReadOnlyVariable<float> Current => _current;

        public void Reduce(float amount)
        {
            if (IsPositiveValue(amount))
                _current.Value = Mathf.Clamp(_current.Value - amount, 0, _max.Value);
        }

        public void Add(float amount)
        {
            if (IsPositiveValue(amount))
                _current.Value = Mathf.Clamp(_current.Value + amount, 0, _max.Value);
        }

        private bool IsPositiveValue(float amount)
        {
            if (amount < 0)
            {
                Debug.LogError($"{nameof(amount)} cannot be negative.)");
                return false;
            }

            return true;
        }
    }

}
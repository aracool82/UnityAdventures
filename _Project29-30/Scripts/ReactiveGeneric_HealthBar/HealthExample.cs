using UnityEngine;

namespace _Project29_30.Scripts.ReactiveGeneric_Health
{
    public class HealthExample : MonoBehaviour
    {
        [SerializeField] private SliderView sliderView;

        private Health _health;

        private void Awake()
        {
            _health = new Health(100, 50);
            sliderView.Initialize(_health.Max, _health.Current);
            _health.Current.Changed += OnHealthChenged;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                _health.Reduce(10);

            if (Input.GetKeyDown(KeyCode.Alpha2))
                _health.Add(10);
        }

        private void OnDestroy()
            => _health.Current.Changed -= OnHealthChenged;

        private void OnHealthChenged(float arg1, float newValue)
        {
            if (newValue <= 0)
                Debug.Log($"Потрачено");
        }
    }
}
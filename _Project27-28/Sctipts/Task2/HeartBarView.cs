using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace _Project27_28.Scripts.Task2
{
    public class HeartBarView : MonoBehaviour
    {
        [SerializeField] private Image _heart;

        private TimerService _timerService;
        private List<Image> _hearts = new();

        public void Initialize(TimerService timerService)
        {
            _hearts.Add(_heart);

            _timerService = timerService;
            _timerService.Changed += OnChange;
            CreateImages((int)_timerService.Duration);
        }

        private void OnDisable()
            => _timerService.Changed -= OnChange;

        private void OnChange()
        {
            if (_timerService.Value == 0)
            {
                _hearts.ForEach(image => image.gameObject.SetActive(true));
                return;
            }

            int index = _hearts.Count - (int)_timerService.Value;
            _hearts[index].gameObject.SetActive(false);
        }

        private void CreateImages(int count)
        {
            Image image;

            for (int i = 0; i < count - 1; i++)
            {
                image = Instantiate(_heart, transform);
                image.transform.SetParent(transform);
                _hearts.Add(image);
            }
        }
    }
}
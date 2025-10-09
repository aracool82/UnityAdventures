using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

namespace _Project27_28.Scripts.Task2
{
    public class HeartBarView : MonoBehaviour
    {
        [SerializeField] private Image _heart;

        private Timer _timer;
        private List<Image> _hearts = new();

        public void Initialize(Timer timer)
        {
            _hearts.Add(_heart);

            _timer = timer;
            _timer.Changed += OnChange;
            CreateImages((int)_timer.Duration);
        }

        private void OnDisable()
            => _timer.Changed -= OnChange;

        private void OnChange()
        {
            if (_timer.Value == 0)
            {
                _hearts.ForEach(image => image.gameObject.SetActive(true));
                return;
            }

            int index = _hearts.Count - (int)_timer.Value;
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
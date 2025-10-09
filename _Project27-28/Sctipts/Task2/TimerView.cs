using TMPro;
using UnityEngine;

namespace _Project27_28.Scripts.Task2
{
    public class TimerView : MonoBehaviour
    {
        private const string Text = "Time : ";
        
        [SerializeField] private TMP_Text _text;
        //[SerializeField] private Timer _timer;
        private Timer _timer;

        // private void OnEnable()
        // {
        //     Debug.Log("TimerView::OnEnable");
        //     
        //     _timer.Changed += OnChange;
        // }
        
        public void Initialize(Timer timer)
        {
            _timer = timer;
            _timer.Changed += OnChange;
        }
        
        private void OnDisable()
            =>_timer.Changed -= OnChange;

        private void OnChange()
            => _text.text =$"{Text} {_timer.Value}";
    }
}
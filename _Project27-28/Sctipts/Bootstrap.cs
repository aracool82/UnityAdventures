using _Project27_28.Scripts.Task1;
using _Project27_28.Scripts.Task2;
using UnityEngine;

namespace _Project27_28.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Storage _storage;
        [SerializeField] private CoinsView _coinsView;
        
        [SerializeField] private Timer _timer;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private float _duration = 10;
        
        [SerializeField] private SliderBarView _sliderBarView;
        [SerializeField] private HeartBarView _heartBarView;
        
        private void Awake()
        {
            //Debug.Log("Bootstrap Awake");
            
            _storage.Initialize(new Wallet());
            _coinsView.OnChanged();
            //------------------------------------------
            _timer.Initialize(new TimerService(_duration));
            _timerView.Initialize(_timer);
            
            _sliderBarView.Initialize(_timer);
            _heartBarView.Initialize(_timer);
            //-------------------------------------------
        }

        private void Update()
        {
            _timer.UpdateLogic(Time.deltaTime);
        }
    }
}
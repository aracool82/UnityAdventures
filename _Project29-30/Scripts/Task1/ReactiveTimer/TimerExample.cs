using _Project29_30.Scripts.ReactiveGeneric_Health;
using UnityEngine;

namespace _Project29_30.Scripts.Task1.ReactiveTimer
{
    public class TimerExample : MonoBehaviour
    {
        [SerializeField] SliderView _sliderView;
        
        private Timer _timer;
        private bool _isStoping = false;
        
        private void Awake()
        {
            _timer = new Timer(5);
            _sliderView.Initialize(_timer.MaxTime,_timer.CurrentTime);
           
        }

        private void OnEnable()
        {
            _timer.IsFinished.Changed += OnTimerFinished;
            _timer.IsStarted.Changed += OnTimerStarted;
            _timer.Start();
        }


        private void Update()
        {
            _timer.Update(Time.deltaTime);
            
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _isStoping =!_isStoping;
                
                if(_isStoping)
                    _timer.Stop();
                else
                     _timer.Resume();                   
            }
            
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                _isStoping = false;
                _timer.Restart();
            }
        }

        private void OnTimerFinished(bool arg1, bool newValue)
        {
            if(newValue)
                Debug.Log("Timer finished");
        }
        
        private void OnTimerStarted(bool oldValue, bool newValue)
        {
            if(newValue)
                Debug.Log("Timer started");
        }
        
        private void OnDestroy()
        {
            _timer.IsStarted.Changed -= OnTimerStarted;
            _timer.IsFinished.Changed -= OnTimerFinished;
        }
    }
}
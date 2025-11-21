using System.Collections;
using UnityEngine;

namespace _Project31.Scripts
{
    public class TimerExample
    {
        private int _maxTime;
        private MonoBehaviour _coroutineStarter;
        private WaitForSeconds _wait;
        private Coroutine _coroutine;
        private int _counter;
        
        public TimerExample(MonoBehaviour coroutineStarter,int maxTime)
        {
            _coroutineStarter = coroutineStarter;
            _maxTime = maxTime;
            _wait = new WaitForSeconds(1);
        }
        
        public bool IsProcess => _coroutine != null;
        
        private IEnumerator Start(int seconds)
        {
            while (true)
            {
                yield return _wait;
                _counter++;
                Debug.Log($"Прошло {_counter} сек. Процесс : {IsProcess}");
                
                if(_counter == _maxTime)
                {
                    _coroutine = null;
                    Debug.Log($"Процесс : {IsProcess}");
                    yield break;
                }
            }
        }

        public void Start()
        {
            _coroutine = _coroutineStarter.StartCoroutine(Start(_maxTime));
        }
    }
}
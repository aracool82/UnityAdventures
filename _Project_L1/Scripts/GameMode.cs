using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project_L1
{
    public class GameMode
    {
        public event Action Win;
        public event Action Defeat;

        private readonly ICoroutinePerformer _coroutinePerformer;
        private Queue<KeyCode> _sequenceKeyCode = new();

        public GameMode(IEnumerable keys, ICoroutinePerformer coroutinePerformer)
        {
            _coroutinePerformer = coroutinePerformer;
            _sequenceKeyCode.EnqueueMany((List<KeyCode>)keys);
        }

        public void Start()
            => _coroutinePerformer.Perform(ProcessSequence());

        private IEnumerator ProcessSequence()
        {
            yield return new WaitForSeconds(0.1f);
            
            while (_sequenceKeyCode.Count > 0)
            {
                KeyCode waitKey = _sequenceKeyCode.Dequeue();
                Debug.Log("Wait Key: " + waitKey);

                yield return new WaitUntil(() => Input.anyKeyDown);

                if (Input.GetKeyDown(waitKey) == false)
                {
                    _sequenceKeyCode.Clear();
                    Defeat?.Invoke();
                    yield break;
                }

                yield return null;
            }

            Win?.Invoke();
        }
    }
}
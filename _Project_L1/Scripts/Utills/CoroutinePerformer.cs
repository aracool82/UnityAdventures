using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public class CoroutinePerformer : MonoBehaviour,ICoroutinePerformer
    {
        private void Awake()
            => DontDestroyOnLoad(this);

        public Coroutine Perform(IEnumerator coroutineFunction)
            => StartCoroutine(coroutineFunction);
        
        public void StopPerform(Coroutine coroutine)
            => StopCoroutine(coroutine);
    }
}
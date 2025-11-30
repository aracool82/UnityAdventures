using System.Collections;
using UnityEngine;

namespace _Project_L1.Scripts.Utils.CoroutineManagement
{
    public interface ICoroutinePerformer
    {
        public Coroutine Perform(IEnumerator coroutineFunction);

        public void StopPerform(Coroutine coroutine);
    }
}
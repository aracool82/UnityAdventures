using System.Collections;
using UnityEngine;

namespace _Project_L1.Scripts
{
    public class LoadingEmulate
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public IEnumerator Simulate(float duration)
        {
            WaitForSeconds wait = new WaitForSeconds(duration);
            
            yield return wait;
        }
    }
}
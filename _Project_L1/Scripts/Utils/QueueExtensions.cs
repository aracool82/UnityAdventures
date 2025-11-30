using System.Collections.Generic;

namespace _Project_L1.Scripts.Utils
{
    public static class QueueExtensions
    {
        public static void EnqueueMany<T>(this Queue<T> queue, IEnumerable<T> items)
        {
            foreach (T item in items)
                queue.Enqueue(item);
        }
    }
}
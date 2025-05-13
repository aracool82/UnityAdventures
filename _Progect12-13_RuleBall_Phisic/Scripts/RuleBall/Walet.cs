using UnityEngine;

namespace _Progect12_13.Scripts
{
    public class Walet
    {
        public int Value { get;private set; }

        public void Add(int amount)
        {
            if(amount < 0)
                Debug.LogError("Not enough amount");
            
            Value += amount;
        }
    }
}
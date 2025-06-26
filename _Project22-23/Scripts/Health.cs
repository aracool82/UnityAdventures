using UnityEngine;

namespace _Project22_23.Scripts
{
    public class Health 
    {
        public readonly float MaxHealth;
        
        public Health(float maxValue)
        {
            Value = maxValue;
            MaxHealth = maxValue;
        }

        public float Value { get; private set; }

        public bool IsAlive => Value > 0;

        public void TakeDamage(float amount)
        {
            if (amount < 0)
            {
                Debug.LogError("amount can't be negative");
                return;
            }

            Value -= amount;

            if (Value < 0)
                Value = 0;
        }
    }
}
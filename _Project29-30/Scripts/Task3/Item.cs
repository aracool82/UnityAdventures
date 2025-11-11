using System;
using UnityEngine;

namespace _Project29_30.Scripts.Task3
{
    public class Item
    {
        public Item(int id, int count, int maxCount)
        {
            Id = id;
            Count = count;
            MaxCount = maxCount;
        }

        public int MaxCount { get; }
        public int Id { get; }
        public int Count { get; private set; }

        public void AddCount(int amount)
        {
            if (IsCorrectValue(amount) && CanAdd(amount))
                Count += amount;
        }

        public bool RemoveCount(int amount)
        {
            if (IsCorrectValue(amount) && CanRemove(amount))
            {
                Count -= amount;
                return true;
            }

            Debug.LogError($"{amount} is not a valid amount.");
            return false;
        }

        public bool CanAdd(int amount)
            => Count + amount <= MaxCount;

        public bool CanRemove(int amount)
            => Count - amount >= 0;

        private bool IsCorrectValue(int amount)
            => (amount < 0 || amount > MaxCount)
                ? throw new ArgumentOutOfRangeException($"{nameof(amount)} Don't be less than 0")
                : true;
    }
}
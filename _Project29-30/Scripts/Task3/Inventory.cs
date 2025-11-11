using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project29_30.Scripts.Task3
{
    public class Inventory
    {
        public readonly int MaxSize;
        private readonly Dictionary<int, Item> _items = new();

        public Inventory(int maxSize)
            => MaxSize = maxSize;

        public int CurrentSize => _items.Values.Sum(item => item.Count);
        public IEnumerable<Item> Items => _items.Values.ToList();

        public void Add(Item item)
        {
            if (item == null)
                throw new ArgumentNullException($"{nameof(item)} cannot be null");

            if (CanAdd(item.Count) == false)
            {
                Debug.LogWarning($"Can't add item. MaxSize inventory: {MaxSize}, current size: {CurrentSize}.");
                return;
            }

            if (_items.ContainsKey(item.Id))
                _items[item.Id].AddCount(item.Count);
            else
                _items.Add(item.Id, item);
        }

        public void RemoveBy(int id, int amount)
        {
            if (_items.ContainsKey(id) == false)
            {
                Debug.Log($"Can't remove item. {nameof(id)} = {id} not found.");
                return;
            }

            if (CanRemoveItem(id, amount))
            {
                _items[id].RemoveCount(amount);

                if (_items[id].Count == 0)
                    _items.Remove(id);
            }
        }

        public Item GetItemsBy(int id, int count)
        {
            Item item = null;

            if (_items.ContainsKey(id))
                item = _items[id];

            RemoveBy(id, count);

            return new Item(item.Id, item.Count, item.MaxCount);
        }

        public bool CanRemoveItem(int id, int count)
        {
            if (_items.TryGetValue(id, out var item))
                return item.CanRemove(count);

            return false;
        }

        private bool CanAdd(int count)
            => MaxSize >= CurrentSize + count;
    }
}
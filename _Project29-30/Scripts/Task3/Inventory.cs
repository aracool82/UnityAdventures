using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Inventory
    {
        private readonly int _maxSize;

        private Dictionary<int, int> _items = new();

        public Inventory(int maxSize)
        {
            _maxSize = maxSize;
        }

        public int CurrentSize => _items.Values.Sum();

        public void Add(Item item)
        {
            if (CurrentSize == _maxSize || item == null)
            {
                Debug.LogError($"Cannot add an item to a Inventory.");
                return;
            }

            if (_items.ContainsKey(item.ID))
                _items[item.ID]++;
            else
                _items.Add(item.ID, 1);
        }

        public List<Item> GetItemsBy(int id) //TODO
        {
            List<Item> items = new();


            if (_items.ContainsKey(id))
            {
                int count = _items[id];

                for (int i = 0; i < count; i++)
                    items.Add(new Item(id));
            }

            return items;
        }
    }

    public class Item
    {
        public Item(int id)
        {
            ID = id;
        }

        public int ID { get; private set; }
    }
}
using UnityEngine;

namespace _Project29_30.Scripts.Task3
{
    public class DicTest : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = new Inventory(20);

            Item item = new Item(-10, 4,20);
           
            Item item2 = new Item(-10, 4,20);
            _inventory.Add(item);
            _inventory.Add(item2);
            
            _inventory.RemoveFor(-10,7);
            Item item3 = _inventory.GetItemsBy(-10, 1);
            
            Debug.Log($"CurrentSize - {_inventory.CurrentSize}.");
            Debug.Log($"item3.Id - {item3.Id}.");
        }
    }
}
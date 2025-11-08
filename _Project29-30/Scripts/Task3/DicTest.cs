using UnityEngine;

namespace _Project29_30.Scripts.Task3
{
    public class DicTest : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = new Inventory(6);

            Item item = new Item(-10, 5,_inventory.MaxSize);
            
            _inventory.Add(item);
            Debug.Log($"CurrentSize - {_inventory.CurrentSize}.");
            
            Item item2 = new Item(-10, 1, _inventory.MaxSize);
            _inventory.Add(item2);
            
            _inventory.RemoveFor(-1,7);
            Debug.Log($"CurrentSize - {_inventory.CurrentSize}.");
        }
    }
}
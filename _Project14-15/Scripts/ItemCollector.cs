using UnityEngine;

namespace _Project14_15.Scripts
{
    [RequireComponent(typeof(ItemHolder))]
    
    public class ItemCollector : MonoBehaviour
    {
        [SerializeField] private ItemHolder _itemHolder;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Item item))
                _itemHolder.Add(item);
        }
    }
}
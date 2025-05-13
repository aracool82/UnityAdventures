using UnityEngine;

namespace _Project14_15.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    [RequireComponent(typeof(UserInput), typeof(ItemCollector))]
    
    public class Character : MonoBehaviour
    {
        [Range(100f, 500f)] [SerializeField] private float _health;

        [Range(5f, 20)] [SerializeField] private float _speed;

        [SerializeField] private Transform _alignmentTransform;

        [SerializeField] private ItemHolder _itemHolder;
        private bool _canUsedItem;

        public void Move(Vector3 direction)
        {
            transform.position += direction * (_speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        public void TryUseItem()
        {
            if (_itemHolder.IsEmpty)
                Debug.Log("Can't use Item.");
            else
                UseItem();
        }

        public void AddHealth(float health)
        {
            if (health < 0)
                Debug.LogError("Can`t add negative health");

            _health += health;
        }

        public void AddSpeed(float speed)
        {
            if (speed < 0)
                Debug.LogError("Can`t add negative speed");

            _speed += speed;
        }

        public void AlignmentItem(Item item)
        {
            item.GetComponent<Collider>().enabled = false;
            item.transform.SetParent(transform);
            item.transform.position = _alignmentTransform.position;
        }
        
        private void UseItem()
            => _itemHolder.Use(gameObject);
    }
}

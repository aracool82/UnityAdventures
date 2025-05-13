using UnityEngine;

namespace _Project14_15.Scripts
{
    public class ItemHolder : MonoBehaviour
    {
        [SerializeField] private Character _character;

        private Item _item;

        public bool IsEmpty => _item == null;

        public void Add(Item item)
        {
            if (item == null)
            {
                Debug.LogError("Can not Add. Item is null");
                return;
            }

            if (IsEmpty)
            {
                _item = item;
                _character.AlignmentItem(_item);
            }
        }

        public void Use(GameObject character)
        {
            _item.Use(character);
            _item = null;
        }
    }
}
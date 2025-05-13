using UnityEngine;

namespace _Project14_15.Scripts
{
    public class SpeedBoost : Item
    {
        [Range(1f,4f)]
        [SerializeField] private float _speed;
        
        public override void Use(GameObject character)
        {
            if(character.TryGetComponent(out Character characterComponent))
            {
                characterComponent.AddSpeed(_speed);
                StartEffect(characterComponent.transform.position);
                Desroy();
            }
        }
    }
}
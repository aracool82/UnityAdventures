using UnityEngine;

namespace _Project14_15.Scripts
{
    public class HealthBoost : Item
    {
        [Range(1f, 100f)]
        [SerializeField] private float _health;
        
        public override void Use(GameObject character)
        {
            if(character.TryGetComponent(out Character characterComponent))
            {
                characterComponent.AddHealth(_health);
                StartEffect(characterComponent.transform.position);
                Desroy();
            }
        }
    }
}
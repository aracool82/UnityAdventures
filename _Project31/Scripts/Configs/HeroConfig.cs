using UnityEngine;

namespace _Project31.Scripts
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Config/HeroConfig")]
    public class HeroConfig : ScriptableObject
    {
        [field: SerializeField] public Hero HeroPrefab {get; private set; }
        [field: SerializeField] public float MoveSpeed {get; private set; }
        [field: SerializeField] public float RotationSpeed {get; private set; }
        [field: SerializeField] public float Health {get; private set; }
        [field: SerializeField] public float Damage {get; private set; }
    }
}
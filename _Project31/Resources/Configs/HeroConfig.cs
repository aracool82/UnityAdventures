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
        [field: SerializeField] public Vector3 StartHeroPosition {get; private set; }
        
        [field: SerializeField] public ProjectileConfig ProjectileConfig {get; private set; }


        [ContextMenu("UpateHeroPosition")]
        public void UpateHeroPosition() => StartHeroPosition = GameObject.FindGameObjectWithTag("HeroPoint").transform.position;

    }
}
using UnityEngine;

namespace _Project31.Scripts
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Config/ProjectileConfig")]
    public class ProjectileConfig : ScriptableObject
    {
        [field: SerializeField] public Projectile ProjectilePrefab { get; private set; }
        [field: SerializeField] public float Damage { get; private set; } = 50;
        [field: SerializeField] public float Speed { get; private set; } = 100;
        [field: SerializeField] public float LiveTime { get; private set; } = 3;
        
    }
}
using UnityEngine;

namespace _Project31.Scripts
{
    public class ProjectileSpawner
    {
        public Projectile Create(ProjectileConfig config,Vector3 position)
        {
            Projectile instance = Object.Instantiate(config.ProjectilePrefab, position, Quaternion.identity);
            
            instance.Initialize(config.Damage, config.LiveTime);
            
            return instance;
        }
    }
}
using UnityEngine;

namespace _Project31.Scripts
{
    public class HeroSpawner
    {
        public Hero Spawn(HeroConfig config,ProjectileSpawner projectileSpawner,ProjectileConfig projectileConfig)
        {
            Hero instance = Object.Instantiate(config.HeroPrefab, config.StartHeroPosition, Quaternion.identity);
            
            instance.Initialize(
                new Mover(instance.transform, config.MoveSpeed),
                new Rotator(instance.transform,config.RotationSpeed),
                new Shooter(projectileSpawner,projectileConfig),
                new Health(config.Health,config.Health));
            
            return instance;
        }
    }
}
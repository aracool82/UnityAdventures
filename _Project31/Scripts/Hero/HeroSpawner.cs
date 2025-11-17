using UnityEngine;

namespace _Project31.Scripts
{
    public class HeroSpawner
    {
        public Hero Spawn(HeroConfig config)
        {
            Hero instance = Object.Instantiate(config.HeroPrefab, config.StartHeroPosition, Quaternion.identity);
            
            instance.Initialize(
                new Mover(instance.transform, config.MoveSpeed),
                new Rotator(instance.transform,config.RotationSpeed),
                new Shooter(config.ProjectileConfig.ProjectilePrefab),
                new Health(config.Health,config.Health));
            
            return instance;
        }
    }
}
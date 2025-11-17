using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private HeroSpawner _heroSpawner;
        private ProjectileSpawner _projectileSpawner;
        private EnemySpawner _enemySpawner;
        private void Awake()
        {
            _heroSpawner = new HeroSpawner();
            _projectileSpawner = new ProjectileSpawner();
            
            
            ProjectileConfig projectileConfig =  Resources.Load<ProjectileConfig>("ProjectileConfig");
            HeroConfig heroConfig = Resources.Load<HeroConfig>("HeroConfig");
            EnemyConfig enemyConfig = Resources.Load<EnemyConfig>("EnemyConfig");
            
            Hero hero = _heroSpawner.Spawn(heroConfig,_projectileSpawner,projectileConfig);
            _enemySpawner = new EnemySpawner(enemyConfig);
        }

        private void Update()
        {
            _enemySpawner.Update(Time.deltaTime);
        }
    }
}
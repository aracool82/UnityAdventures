using System.Collections.Generic;
using UnityEngine;

namespace _Project31.Scripts
{
    public class EnemySpawner
    {
        private EnemyConfig _config;
        private float _time;
        private List<Enemy> _enemies = new();

        public EnemySpawner(EnemyConfig config)
        {
            _config = config;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _config.TimeToChangeDirection)
            {
                _time = 0;
                Spawn();
            }
        }

        private void Spawn()
        {
            Enemy enemy = GameObject.Instantiate(
                _config.EnemyPrefab,
                _config.SpawnPints[Random.Range(0, _config.SpawnPints.Count)] + new Vector3(0,1,0),
                Quaternion.identity);

            enemy.Initialize(
                new Health(_config.Health, _config.Health),
                new Mover(enemy.transform, _config.MoveSpeed),
                _config.Damage,
                _config.TimeToChangeDirection);

            _enemies.Add(enemy);
        }
    }
}
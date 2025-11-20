using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project31.Scripts
{
    public class EnemySpawner
    {
        private EnemyConfig _config;
        private List<Enemy> _enemies = new();
        private float _time;
        private int _killedEnemies = 0;
        private bool _isRunning = false;

        public EnemySpawner(EnemyConfig config)
            => _config = config;

        public int EnemiesCount => _enemies.Count;
        public int KilledEnemies => _killedEnemies;

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;

            _time += deltaTime;

            if (_time >= _config.TimeToSpawn)
            {
                _time = 0;
                Spawn();
            }
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Stop()
        {
            _time = 0;
            _isRunning = false;
            KillAllEnemies();
        }

        private void Spawn()
        {
            Enemy enemy = GameObject.Instantiate(
                _config.EnemyPrefab,
                _config.SpawnPints[Random.Range(0, _config.SpawnPints.Count)] + new Vector3(0, 1, 0),
                Quaternion.identity);

            enemy.Initialize(
                new Health(_config.Health, _config.Health),
                new Mover(enemy.transform, _config.MoveSpeed),
                _config.Damage,
                _config.TimeToChangeDirection);

            _enemies.Add(enemy);
            enemy.Dead += OnDeadEnemy;
        }

        private void OnDeadEnemy(Enemy enemy)
        {
            enemy.Dead -= OnDeadEnemy;
            _killedEnemies++;

            Object.Destroy(enemy.gameObject);
            _enemies.Remove(enemy);
        }

        private void KillAllEnemies()
        {
            foreach (Enemy enemy in _enemies)
                GameObject.Destroy(enemy.gameObject);
            
            _enemies.Clear();
        }
    }
}
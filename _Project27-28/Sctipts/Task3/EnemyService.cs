using System.Collections.Generic;
using UnityEngine;

namespace _Project27_28.Scripts.Task3
{
    public class EnemyService : IUpdateble
    {
        private int _limitEnemies;
        private List<Enemy> _enemies;

        public EnemyService(int limitEnemies)
        {
            _limitEnemies = limitEnemies;
            _enemies = new();
        }

        public void UpdateLogic(float deltaTime)
            => Debug.Log($"В списке : {_enemies.Count} Enemy");

        public void AddEnemy(Enemy enemy)
        {
            if (enemy == null || _enemies.Count == _limitEnemies)
            {
                Debug.Log("Не возможно добавить Enemy");
                return;
            }
                
            Subscribe(enemy);
            _enemies.Add(enemy);
        }

        private void OnDead(Enemy enemy)
        {
            UnSubscribe(enemy);
            _enemies.Remove(enemy);
        }

        private void Subscribe(Enemy enemy)
            => enemy.Deaed += OnDead;

        private void UnSubscribe(Enemy enemy)
            => enemy.Deaed -= OnDead;
    }
}
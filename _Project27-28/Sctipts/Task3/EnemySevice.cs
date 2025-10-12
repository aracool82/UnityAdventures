using System.Collections.Generic;
using UnityEngine;

namespace _Project27_28.Scripts.Task3
{
    public class EnemySevice 
    {
        private List<Enemy> _enemies = new();

        public void UpdateLogic()
            =>Debug.Log($"В списке : {_enemies.Count} Enemy");

        public void AddEnemy(Enemy enemy)
        {
            if(enemy == null)
                return;
            
            Subscribe(enemy);
            _enemies.Add(enemy);
        }
        
        private void OnDead(Enemy enemy)
        {
            UnSubscribe(enemy);
            _enemies.Remove(enemy);
        }
        
        private void Subscribe(Enemy enemy)
            =>enemy.Deaed += OnDead;
        
        private void UnSubscribe(Enemy enemy)
            =>enemy.Deaed -= OnDead;

        // private void RemoveEnemyBy(Func<int, int, bool> conditionDestroyByCount, int enemyCount, int controlValue)
        // {
        //     if (conditionDestroyByCount.Invoke(enemyCount, controlValue))
        //         _enemies.RemoveRange(0, enemyCount - controlValue);
        // }
        //
        // private void RemoveEnemyBy(Func<Enemy, bool> conditionDestroyBy)
        //     => _enemies.RemoveAll(enemy => conditionDestroyBy(enemy));
        //
        // private bool IsLessA(int a, int b)
        //     => a > b;
    }
}
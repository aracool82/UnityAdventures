using System;
using UnityEngine;

namespace _Project27_28.Scripts.Task3
{
    public class CreaterEnemyWithCondition : IUpdateble
    {
        private EnemyService _enemyService;
        private Updater _updater;

        public CreaterEnemyWithCondition(EnemyService enemyService, Updater updater)
        {
            _enemyService = enemyService;
            _updater = updater;
            _updater.AddUpadateble(enemyService);
            _updater.AddUpadateble(this);
        }

        public void UpdateLogic(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Enemy enemy = new Enemy(10);
                AddNewEnemy(enemy, () => enemy.IsDead);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Enemy enemy = new Enemy(10);
                AddNewEnemy(enemy, () => enemy.CurrentTime >= 5f);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Enemy enemy = new Enemy(20);
                AddNewEnemy(enemy);
            }
        }

        private void AddNewEnemy(Enemy enemy, Func<bool> condition = null)
        {
            enemy.SetConditionDead(condition);
            _enemyService.AddEnemy(enemy);
            _updater.AddUpadateble(enemy);
        }
    }
}

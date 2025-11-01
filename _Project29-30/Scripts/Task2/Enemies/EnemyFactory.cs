using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project29_30.Scripts.Task2
{
    public class EnemyFactory
    {
        private List<Enemy> _enemiesPrefab;

        public EnemyFactory(List<Enemy> enemiesPrefab)
        {
            _enemiesPrefab = enemiesPrefab;
        }

        public Dragon CreateDragon(DragonSetting dragonSetting, Vector3 position)
        {
            Enemy enemyPrefab = GetEnemy(enemy => enemy.GetComponent<Dragon>() != null);
            Dragon instance = Object.Instantiate(enemyPrefab, position, Quaternion.identity, null)
                .GetComponent<Dragon>();
            instance.Initialize(dragonSetting.Health, dragonSetting.Damage);
            return instance;
        }
        
        public Ork CreateOrc(OrkSetting orkSetting, Vector3 position)
        {
            Enemy enemyPrefab = GetEnemy(enemy => enemy.GetComponent<Ork>() != null);
            Ork instance = Object.Instantiate(enemyPrefab, position, Quaternion.identity, null)
                .GetComponent<Ork>();
            instance.Initialize(orkSetting._speed, orkSetting._isDead);
            return instance;
        }
        
        public Elf CreateElf(ElfSetting elfSetting, Vector3 position)
        {
            Enemy enemyPrefab = GetEnemy(enemy => enemy.GetComponent<Elf>() != null);
            Elf instance = Object.Instantiate(enemyPrefab, position, Quaternion.identity, null)
                .GetComponent<Elf>();
            instance.Initialize(elfSetting.Position, elfSetting.Rotation,elfSetting.Name);
            return instance;
        }
        
        private Enemy GetEnemy(Func<Enemy,bool> filter)
        {
            foreach (var enemy in _enemiesPrefab)
                if (filter.Invoke(enemy))
                    return enemy;
            
            return null;        
        }

    }
}
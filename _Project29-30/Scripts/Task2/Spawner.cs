using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemiesPrefab;
        [SerializeField] private EnemySetting _enemySetting;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var dragonSetting = _enemySetting.GetRandomDragonSetting();
                Enemy enemy = CreateEnemyBy(EnemyTypes.Dragon);
                Dragon dragon = (Dragon)enemy;
                dragon.Initialize(dragonSetting.Health, dragonSetting.Damage);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var elfSetting = _enemySetting.GetRandomElfSetting();
                Enemy enemy = CreateEnemyBy(EnemyTypes.Elf);
                Elf elf = (Elf)enemy;
                elf.Initialize(elfSetting.Position, elfSetting.Rotation, elfSetting.Name);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                var orkSetting = _enemySetting.GetRandomOrkSetting();
                Enemy enemy = CreateEnemyBy(EnemyTypes.Ork);
                Ork ork = (Ork)enemy;
                ork.Initialize(orkSetting.Speed, orkSetting.IsDead);
            }
        }

        private Enemy CreateEnemyBy(EnemyTypes type, Vector3 position = default(Vector3))
        {
            Enemy prefab = _enemiesPrefab.First(findEnemy => findEnemy.Type == type);
            Enemy instance = Instantiate(prefab, position, Quaternion.identity, null);

            return instance;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemiesPrefab;
        [SerializeField] private EnemySetting _enemySetting;

        private Dictionary<EnemyTypes, Enemy> _enemies = new();

        private void Awake()
        {
            foreach (Enemy enemy in _enemiesPrefab)
                _enemies.Add(enemy.Type, enemy);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var dragonSetting = _enemySetting.GetRandomDragonSetting();
                Enemy enemy = CreateEnemyBy(EnemyTypes.Dragon,new Vector3(2,0,0));
                Dragon dragon = (Dragon)enemy;
                dragon.Initialize(dragonSetting.Health, dragonSetting.Damage);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var elfSetting = _enemySetting.GetRandomElfSetting();
                Enemy enemy = CreateEnemyBy(EnemyTypes.Elf,new Vector3(1,0,0));
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
            => Instantiate(_enemies[type], position, Quaternion.identity, null);
    }
}
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemiesPrefab;
        [SerializeField] private List<DragonSetting> _dragonSetings;

        //[SerializeField] private GlobalSetting _setting;
        private void Awake()
        {
            //_setting = new GlobalSetting(_enemiesPrefab);
            _dragonSetings = new List<DragonSetting>()
            {
                new DragonSetting(10, 40),
                new DragonSetting(10, 10)
            };
        }
    }

    [Serializable]
    public class GlobalSetting
    {
        [SerializeField] private List<DragonSetting> _dragonSetings;
        [SerializeField] private List<ElfSetting> _elfSetings;
        [SerializeField] private List<OrkSetting> _orkSetings;

        private List<Enemy> _enemiesPrefab;
        private EnemyFactory _enemyFactory;

        public GlobalSetting(List<Enemy> enemiesPrefab)
        {
            _enemiesPrefab = enemiesPrefab;
            _enemyFactory = new EnemyFactory(_enemiesPrefab);
            Create();
        }

        private void Create()
        {
            _enemyFactory = new EnemyFactory(_enemiesPrefab);

            _dragonSetings.Add(new DragonSetting(100, 100));
            _dragonSetings.Add(new DragonSetting(200, 200));
            _dragonSetings.Add(new DragonSetting(200, 200));


            _elfSetings.Add(new ElfSetting(new Vector3(1, 0, 0), Quaternion.identity, "Elf1"));
            _elfSetings.Add(new ElfSetting(new Vector3(2, 0, 0), Quaternion.identity, "Elf2"));
            _elfSetings.Add(new ElfSetting(new Vector3(3, 0, 0), Quaternion.identity, "Elf3"));

            _orkSetings.Add(new OrkSetting(2, false));
            _orkSetings.Add(new OrkSetting(4, false));
            _orkSetings.Add(new OrkSetting(6, false));
        }
    }
}
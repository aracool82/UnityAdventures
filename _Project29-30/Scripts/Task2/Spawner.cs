using System.Collections.Generic;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private List<Enemy> _enemies;
        
        private EnemyFactory _enemyFactory;
        
        private void Awake()
        {
            _enemyFactory = new EnemyFactory(_enemies);
            
            Dragon dragon = _enemyFactory.CreateDragon(new DragonSetting(100,100), Vector3.zero);
            Elf elf = _enemyFactory.CreateElf(new ElfSetting(new Vector3(1, 1, 1), Quaternion.identity, "Elf"),Vector3.right);
            Ork ork =  _enemyFactory.CreateOrc(new OrkSetting(10,false),Vector3.left);
        }
    }
}
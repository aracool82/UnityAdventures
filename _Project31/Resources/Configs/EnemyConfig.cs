using System.Collections.Generic;
using UnityEngine;

namespace _Project31.Scripts
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public  Enemy EnemyPrefab { get; private set; }
        [field: SerializeField] public float TimeToChangeDirection { get; private set; } = 2;
        [field: SerializeField] public float TimeToSpawn { get; private set; } = 3;
        
        [field: SerializeField] public float MoveSpeed { get; private set; } = 4;
        [field: SerializeField] public float Health { get; private set; } = 200;
        [field: SerializeField] public float Damage { get; private set; } = 100f;
        [field: SerializeField] public int MaxEnemyCount { get; private set; } = 10;
        [field: SerializeField] public List<Vector3> SpawnPints { get; private set; } = new();
        
        [ContextMenu("UpdateSpawnPints")]
        public void UpdateSpawnPints()
        {
            SpawnPints.Clear();

            var result = GameObject.FindGameObjectsWithTag("EnemyPoint");

            foreach (var gameObject in result)
                SpawnPints.Add(gameObject.transform.position);
        }
    }
}
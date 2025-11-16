using UnityEngine;

namespace _Project31.Scripts
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Config/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public  Enemy EnemyPrefab { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; } 
        [field: SerializeField] public float Health {get; private set; }
        [field: SerializeField] public float Damage {get; private set; }
    }
}
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public abstract class Enemy : MonoBehaviour
    {
        [field: SerializeField] public EnemyTypes Type {get; private set; }
    }
}
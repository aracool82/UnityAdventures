using System.Collections.Generic;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private Enemy _prefabEnemy;

        private List<Vector3> _points = new();

        private void Awake()
        {
            _points = GetPoints();
           // SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            Enemy enemy = Instantiate(_prefabEnemy, transform.position, Quaternion.identity);
            enemy.Initialize(_characterTransform,_particle);
        }

        private List<Vector3> GetPoints()
        {
            List<Vector3> points = new();
            int childCount = transform.childCount;
            int minCount = 2;

            if (childCount < minCount)
                Debug.LogError($"Minimum Transform count is {minCount}");

            for (int i = 0; i < childCount; i++)
                points.Add(transform.GetChild(i).position);
            
            return points;
        }
    }
}
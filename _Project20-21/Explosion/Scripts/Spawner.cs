using System.Collections.Generic;
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Box _boxPrefab;
        [SerializeField] private int _count;
        [SerializeField] private float _horizontalX;
        [SerializeField] private float _verticalZ;
        [SerializeField] private Selector _selector;
        
        private List<IExploded> _explodedBoxes = new List<IExploded>();
        
        public  List<IExploded> ExplodedBoxes => _explodedBoxes; 
        
        private void Awake()
        {
            CreateBoxes();
        }

        private void CreateBoxes()
        {
            for (int i = 0; i < _count; i++)
            {
                Box box = Instantiate(_boxPrefab, GetRandomPosition(), Quaternion.identity, transform);
                _explodedBoxes.Add(box);
            }
            
            AddReferenceAtSpawner();
        }

        private void AddReferenceAtSpawner()
        {
            foreach (IExploded box in _explodedBoxes)
                box.Initialize(this);
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(-1 * _horizontalX, _horizontalX), 0, Random.Range(-1 * _verticalZ, _verticalZ));
        }
    }
}
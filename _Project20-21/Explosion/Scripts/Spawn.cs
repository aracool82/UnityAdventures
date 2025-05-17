using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Spawn : MonoBehaviour
    {
        [SerializeField] private Box _boxPrefab;
        [SerializeField] private int _count;
        [SerializeField] private float _horizontalX;
        [SerializeField] private float _verticalZ;

        void Start()
        {
            CreateBoxes();
        }

        private void CreateBoxes()
        {
            for (int i = 0; i < _count; i++)
            {
                Box box = Instantiate(_boxPrefab, GetRandomPosition(), Quaternion.identity, transform);
            }
        }

        private Vector3 GetRandomPosition()
        {
            return new Vector3(Random.Range(-1 * _horizontalX, _horizontalX), 0,
                Random.Range(-1 * _verticalZ, _verticalZ));
        }
    }
}
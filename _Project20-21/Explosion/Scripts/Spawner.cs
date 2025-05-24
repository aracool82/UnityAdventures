using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _moverCurve;
        [SerializeField] private Box _boxPrefab;
        [SerializeField] private int _count;
        [SerializeField] private float _horizontalX;
        [SerializeField] private float _verticalZ;


        private void Awake()
            => CreateBoxes();

        private void CreateBoxes()
        {
            for (int i = 0; i < _count; i++)
            {
                Box box = Instantiate(_boxPrefab, GetRandomPosition(), Quaternion.identity, transform);
                box.name = $"Box_{i}";
            }
        }

        private Vector3 GetRandomPosition()
            => new Vector3(Random.Range(-1 * _horizontalX, _horizontalX), 0, Random.Range(-1 * _verticalZ, _verticalZ));
    }
}
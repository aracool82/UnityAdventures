using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _boomEffectPrefab;
        [SerializeField] private float _explosionPower;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionUpwardModifier;
        
        [SerializeField] private LayerMask _boxLayerMask;

        [SerializeField] private Box _boxPrefab;
        [SerializeField] private int _count;
        [SerializeField] private float _horizontalX;
        [SerializeField] private float _verticalZ;

         private Exploder _exploder;

         private void Awake()
         {
             ParticleSystem boomEffect = Instantiate(_boomEffectPrefab,transform.position, Quaternion.identity, null);
             _exploder = new Exploder(boomEffect, _explosionPower,_explosionUpwardModifier);
             CreateBoxes();
         }

        private void CreateBoxes()
        {
            for (int i = 0; i < _count; i++)
            {
                Box box = Instantiate(_boxPrefab, GetRandomPosition(), Quaternion.identity, transform);
                box.name = $"Box_{i}";
                box.Initialaze(_exploder, _explosionRadius, _boxLayerMask);
            }
        }

        private Vector3 GetRandomPosition()
            => new Vector3(Random.Range(-1 * _horizontalX, _horizontalX), 0, Random.Range(-1 * _verticalZ, _verticalZ));
    }
}
using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Projectile : MonoBehaviour
    {
        private float _damage;
        private float _liveTime;
        private float _speed;
        
        public float Damage => _damage;

        public void Initialize(float damage, float liveTime, float speed)
        {
            _damage = damage;
            _liveTime = liveTime;
            _speed = speed;
        }
        
        private void Update()
        {
            _liveTime -= Time.deltaTime;
            
            if(_liveTime <= 0)
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.collider.TryGetComponent(out IDamageble damageble))
                damageble.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

namespace _Project31.Scripts
{
    public class Projectile : MonoBehaviour
    {
        private float _damage;
        private float _liveTime;

        public void Initialize(float damage, float liveTime)
        {
            _damage = damage;
            _liveTime = liveTime;
        }
        
        private void Update()
        {
            _liveTime -= Time.deltaTime;
            
            if(_liveTime <= 0)
                Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if(other.collider.TryGetComponent(out IEnemyDamageble damageble))
                damageble.TakeDamage(_damage);
            
            Destroy(gameObject);
        }
    }
}
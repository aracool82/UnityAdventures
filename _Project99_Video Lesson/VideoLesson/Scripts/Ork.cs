using UnityEngine;

namespace _Project_Video_Lesson.Scripts
{
    public class Ork
    {
        private string _name = "OrkBase";
        private float _health = 100f;
        private float _damage = 10f;
        
         
        public string Name => _name;
        public float Health => _health;
        public float Damage => _damage;
        
        // public string Name { get; private set; } = "Ork";
        // public float Health { get;private set; } = 100.0f;
        // public float Damage { get; private set; } = 10.0f;

        public void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                Debug.LogError("Error - Damage < 0");
                return;
            }
            
            _health -= damage;

            if (_health <= 0)
            {
                _health = 0;
                Debug.Log($"Ork - {_name} - Dead.");
            }
        }
    }
}
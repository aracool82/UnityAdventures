using System;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    [Serializable]
    public class DragonSetting : ISelectableSetting
    {
        public DragonSetting(int health, float damage)
        {
            Health = health;
            Damage = damage;
        }

        [field: SerializeField,Min(0)] public int Health { get; private set; }
        [field:SerializeField,Min(0)] public float Damage { get; private set; }
        [field:SerializeField]public bool IsSelected { get; set; }
        
        
    }
}
using System;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    [Serializable]
    public class OrkSetting : ISelectableSetting
    {
        public OrkSetting(float speed, bool isDead)
        {
            _speed = speed;
            _isDead = isDead;
        }

        [field:SerializeField,Min(0)] public float _speed;
        [field:SerializeField] public bool _isDead;
        [field:SerializeField] public bool IsSelected { get; set; }
    }
}
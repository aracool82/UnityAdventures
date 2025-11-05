using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project29_30.Scripts.Task2
{
    [Serializable]
    public class EnemySetting
    {
        [SerializeField] private List<DragonSetting> _dragonSettings = new();
        [SerializeField] private List<ElfSetting> _elfSettings = new();
        [SerializeField] private List<OrkSetting> _orkSettings = new();


        public DragonSetting GetRandomDragonSetting() => _dragonSettings[Random.Range(0, _dragonSettings.Count)];
        public ElfSetting GetRandomElfSetting() => _elfSettings[Random.Range(0, _elfSettings.Count)];
        public OrkSetting GetRandomOrkSetting() => _orkSettings[Random.Range(0, _orkSettings.Count)];

        [Serializable]
        public class DragonSetting
        {
            [field: SerializeField, Min(0)] public int Health { get; private set; }
            [field: SerializeField, Min(0)] public float Damage { get; private set; }
        }

        [Serializable]
        public class ElfSetting
        {
            [field:SerializeField] public Vector3 Position;
            [field:SerializeField] public Quaternion Rotation;
            [field:SerializeField] public string Name;
        }

        [Serializable]
        public class OrkSetting
        {
            [field:SerializeField, Min(0)] public float Speed;
            [field:SerializeField] public bool IsDead;
        }
    }
}
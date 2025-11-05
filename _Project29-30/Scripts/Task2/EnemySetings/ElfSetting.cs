using System;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    [Serializable]
    public class ElfSetting:ISelectableSetting
    {
        public ElfSetting(Vector3 position, Quaternion rotation, string name)
        {
            Position = position;
            Rotation = rotation;
            Name = name;
        }

        [field: SerializeField] public Vector3 Position;
        [field: SerializeField] public Quaternion Rotation;
        [field: SerializeField] public string Name;

        [field: SerializeField] public bool IsSelected { get; set; }
    }
}
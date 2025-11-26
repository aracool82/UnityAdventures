using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Project_L1
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        private List<KeyCode> _numbers => Enum.GetValues(typeof(KeyCode))
            .OfType<KeyCode>()
            .Where(k => k >= KeyCode.Alpha0 && k <= KeyCode.Alpha9)
            .ToList();

        private List<KeyCode> _chars => Enum.GetValues(typeof(KeyCode))
            .OfType<KeyCode>()
            .Where(k => k >= KeyCode.A && k <= KeyCode.Z)
            .ToList();

        [field: SerializeField] public List<KeyCode> Numbers;
        [field: SerializeField] public List<KeyCode> Chars;

        private void OnValidate()
            => Initialize();

        private void OnEnable()
            => Initialize();

        private void Initialize()
        {
            Numbers = new List<KeyCode>(_numbers);
            Chars = new List<KeyCode>(_chars);
        }
    }
}
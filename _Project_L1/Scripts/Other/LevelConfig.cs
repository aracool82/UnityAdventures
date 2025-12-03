using System.Collections.Generic;
using UnityEngine;

namespace _Project_L1.Scripts
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        private Dictionary<SequenceTypes, IEnumerable<KeyCode>> _sequences = new()
        {
            {SequenceTypes.Numbers, new[]{KeyCode.Alpha1,KeyCode.Alpha1,KeyCode.Alpha1}},
            { SequenceTypes.Chars ,new[] {KeyCode.Q,KeyCode.W,KeyCode.E}}
        };
        
        public IEnumerable<KeyCode> GetSequence(SequenceTypes sequenceType)
            => _sequences.ContainsKey(sequenceType) ? _sequences[sequenceType] : new List<KeyCode>();
    }
}
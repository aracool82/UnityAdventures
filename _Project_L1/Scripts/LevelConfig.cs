using System.Collections.Generic;
using UnityEngine;

namespace _Project_L1
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public List<KeyCode> Numbers = new() 
            { 
                KeyCode.Alpha1,
                KeyCode.Alpha1,
                KeyCode.Alpha2,
                KeyCode.Alpha2,
                KeyCode.Alpha2
            };
        
        [field: SerializeField] public List<KeyCode> Chars = new() 
        { 
            KeyCode.Q,
            KeyCode.W,
            KeyCode.E,
            KeyCode.R,
            KeyCode.T
        };
    }
}
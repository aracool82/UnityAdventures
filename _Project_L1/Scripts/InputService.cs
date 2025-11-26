using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project_L1
{
    public class InputService
    {
        public event Action<KeyCode> PressedKey;
        
        private List<KeyCode> _keys = new List<KeyCode>();

        public void SetKeys(List<KeyCode> keys)
        {
            if(keys == null)
                return;
            
            _keys = keys;
        }

        public void Update()
        {
            if(Input.anyKey == false && _keys.Count == 0)
                return;
            
            foreach (KeyCode key in _keys)
                if(Input.GetKeyDown(key))
                    PressedKey?.Invoke(key);
        }
    }
}
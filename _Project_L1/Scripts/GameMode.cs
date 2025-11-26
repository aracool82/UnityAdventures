using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project_L1
{
    public class GameMode : IDisposable
    {
        public event Action Win;
        public event Action Defeat;

        private InputService _input;
        private LevelConfig _config;
        private List<KeyCode> _keys = new();

        private SequenceTypes _sequence;
        private bool _isRunning;
        
        public GameMode(LevelConfig config, List<KeyCode> keys, SequenceTypes sequence = SequenceTypes.Numbers)
        {
            _config = config;
            _keys = keys;
            _input = new InputService();
            _input.PressedKey += OnPressedKey;
            SetSequence(sequence);
        }

        public void Update()
        {   
            if(_isRunning == false)
                return;
            
            _input.Update();
        }
        
        public void Start()
            => _isRunning = true;
        
        private void OnPressedKey(KeyCode pressedKey)
        {
            if (_keys.Count == 0)
                return;

            KeyCode key = _keys[0];

            if (pressedKey == key)
            {
                _keys.Remove(key);

                if (_keys.Count == 0)
                {
                    Win?.Invoke();
                    Stop();
                }
            }
            else
            {
                Defeat?.Invoke();
                Stop();
            }
        }

        public void SetSequence(SequenceTypes sequence)
        {
            _sequence = sequence;

            if (_sequence == SequenceTypes.Numbers)
                _input.SetKeys(_config.Numbers);
            else if (_sequence == SequenceTypes.Chars)
                _input.SetKeys(_config.Chars);
        }

        public void Dispose()
            => _input.PressedKey -= OnPressedKey;
        
        private void Stop()
        {
            Dispose();
            _isRunning = false;
        }
    }
}
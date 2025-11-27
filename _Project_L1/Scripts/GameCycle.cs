using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Project_L1
{
    public class GameCycle : IDisposable
    {
        private readonly ICoroutinePerformer _coroutinePerformer;
        private GameMenu _gameMenu;
        private GameMode _gameMode;
        private LevelConfig _levelConfig;
        private ResultGameType _resultGameType;

        public GameCycle(GameMenu gameMenu, LevelConfig levelConfig, ICoroutinePerformer coroutinePerformer)
        {
            _levelConfig = levelConfig;
            _gameMenu = gameMenu;
            _coroutinePerformer = coroutinePerformer;
        }

        public void Start()
            => _coroutinePerformer.Perform(Prepare());

        private IEnumerator Prepare()
        {
            _gameMenu.Show();
            yield return _gameMenu.WaitSelectedMod();
            Debug.Log($"Selected Mod : {_gameMenu.SequenceType}");
            _gameMenu.Hide();

            CreateGameMode();

            Subscribe();
            _gameMode.Start();
        }

        private void CreateGameMode()
        {
            if (_gameMenu.SequenceType == SequenceTypes.Numbers)
                _gameMode = new GameMode(_levelConfig.Numbers, _coroutinePerformer);
            else if (_gameMenu.SequenceType == SequenceTypes.Chars)
                _gameMode = new GameMode(_levelConfig.Chars, _coroutinePerformer);
            else
                Debug.LogError("Incorrect sequence type");
        }
        
        private IEnumerator WaitPressSpace()
        {
            Unsubscribe();
            string message = _resultGameType == ResultGameType.Win ? "selected Menu" : "retry game";
            Debug.Log($"Press Space for {message}");
            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            if (_resultGameType == ResultGameType.Win)
            {
                _coroutinePerformer.Perform(Prepare());
            }
            else if (_resultGameType == ResultGameType.Defeat)
            {
                CreateGameMode();
                Subscribe();
                _gameMode.Start();
            }
        }
        
        private void OnDefeat()
        {
            Debug.Log("Defeat");
            Debug.Log("++++++++++++++++++++++++++++++++++");
            _resultGameType = ResultGameType.Defeat;
            _coroutinePerformer.Perform(WaitPressSpace());
        }

        private void OnWin()
        {
            Debug.Log("Win");
            Debug.Log("++++++++++++++++++++++++++++++++++");
            _resultGameType = ResultGameType.Win;
            _coroutinePerformer.Perform(WaitPressSpace());
        }

        private void Subscribe()
        {
            _gameMode.Win += OnWin;
            _gameMode.Defeat += OnDefeat;
        }

        private void Unsubscribe()
        {
            _gameMode.Win -= OnWin;
            _gameMode.Defeat -= OnDefeat;
        }

        public void Dispose()
            => Unsubscribe();
    }
}
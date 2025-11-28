using System;
using System.Collections;
using System.Collections.Generic;
using _Project_L1.Scripts.Infrastructure;
using UnityEngine;

namespace _Project_L1
{
    public class GameCycle : IDisposable
    {
        private readonly ICoroutinePerformer _coroutinePerformer;
        private readonly ModeFactory _modeFactory;

        private IModeService _modeService;
        private GameMenu _gameMenu;
        private LevelConfig _levelConfig;
        private ResultGameType _resultGameType;

        public GameCycle(GameMenu gameMenu, LevelConfig levelConfig, ModeFactory modeFactory,
            ICoroutinePerformer coroutinePerformer)
        {
            _levelConfig = levelConfig;
            _gameMenu = gameMenu;
            _modeFactory = modeFactory;
            _coroutinePerformer = coroutinePerformer;
        }

        public void Start()
            => _coroutinePerformer.Perform(Prepare());

        private IEnumerator Prepare()
        {
            yield return _gameMenu.ShowWithWait();
            CreateAndStartGameMode();
        }
        
        private void CreateAndStartGameMode()
        {
            CreateGameMode(_gameMenu.SequenceType);
            Subscribe();
            _modeService.Start();
        }
        
        private void CreateGameMode(SequenceTypes type)
        {
            switch (type)
            {
                case SequenceTypes.Numbers:
                    _modeService = _modeFactory.CreateMode(_levelConfig, type, _coroutinePerformer);
                    break;
                
                case SequenceTypes.Chars:
                    _modeService = _modeFactory.CreateMode(_levelConfig, type, _coroutinePerformer);
                    break;
                
                default:
                    throw new AggregateException($"Unknown sequence type: {type}");
            }
        }

        private IEnumerator WaitPressSpace()
        {
            Unsubscribe();
            string message = _resultGameType == ResultGameType.Win ? "selected Menu" : "retry game";
            Debug.Log($"Press Space for {message}");

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            if (_resultGameType == ResultGameType.Win)
                _coroutinePerformer.Perform(Prepare());
            else if (_resultGameType == ResultGameType.Defeat)
                CreateAndStartGameMode();
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
            _modeService.Win += OnWin;
            _modeService.Defeat += OnDefeat;
        }

        private void Unsubscribe()
        {
            _modeService.Win -= OnWin;
            _modeService.Defeat -= OnDefeat;
        }

        public void Dispose()
            => Unsubscribe();
    }
}
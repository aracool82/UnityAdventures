using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Project_L1
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private LoadingScreen _loadingScreen;
        [SerializeField] private ConfirmPopup _confirmPopup;

        private InputService _inputService;
        private GameMode _gameMode;

        private void Awake()
        {
            StartCoroutine(ProcessStart());
        }

        private void OnPressedKey(KeyCode key)
        {
            Debug.Log($"Pressed key: {key} / {(int)key}");
        }

        private void Update()
        {
            _gameMode?.Update();
        }

        private IEnumerator ProcessStart()
        {
            _loadingScreen.Show();
            //создание каких то вспомогательных сервисов
            //процесс создания рекламных аналитик,сервисов
            //подгрузка настроек
            //загрузка или генерация уровня.окружения
            //другие подготовительные операции
            //симуляции какой-то инициализации
            yield return new WaitForSeconds(0.3f);
            _loadingScreen.Hide();

            _confirmPopup.SetMessage($" Press {KeyCode.Alpha1}\n or       {KeyCode.Alpha2}\n to continue...");
            _confirmPopup.Show();
            yield return _confirmPopup.WaitConfirm(KeyCode.Alpha1, KeyCode.Alpha2);
            _confirmPopup.Hide();

            LevelConfig levelConfig = Resources.Load<LevelConfig>("Configs/LevelConfig");

            List<KeyCode> keys = new( ){ KeyCode.Alpha1, KeyCode.Alpha2 };
            _gameMode = new GameMode(levelConfig, keys, SequenceTypes.Numbers);
            _gameMode.Win += OnWin;
            _gameMode.Defeat += OnDefeat;
            _gameMode.Start();
        }

        private void OnDefeat()
        {
            Debug.Log("Defeat");
        }

        private void OnWin()
        {
            Debug.Log("Win");
        }

        private void OnDestroy()
        {
            _gameMode.Win -= OnWin;
            _gameMode.Defeat -= OnDefeat;
        }
    }
}
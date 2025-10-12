using System.Collections.Generic;
using _Project27_28.Scripts.Task1;
using _Project27_28.Scripts.Task2;
using _Project27_28.Scripts.Task3;
using UnityEngine;

namespace _Project27_28.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CoinsView _coinsView;

        [SerializeField] private float _duration = 10;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private SliderBarView _sliderBarView;
        [SerializeField] private HeartBarView _heartBarView;

        [SerializeField] private EnemySevice _enemyService;

        private TimerService _timerService;

        private List<Enemy> _enemies = new();
        private Updater _updater;

        private void Awake()
        {
            _updater = new Updater();

            InitWallet();

            InitTimerService();

            InitEnemys();
        }

        private void Update()
            => _updater.UpdateLogic(Time.deltaTime);

        private void InitWallet()
            =>_coinsView.Initialize(new Wallet());

        private void InitTimerService()
        {
            _timerService = new TimerService(_duration);

            _timerView.Initialize(_timerService);
            _sliderBarView.Initialize(_timerService);
            _heartBarView.Initialize(_timerService);

            _updater.AddUpadateble(_timerService);
        }
        
        private void InitEnemys()
        {
            int enemyCount = 5;
            CreateEnemys(enemyCount);
            //_enemyService.Initialize(_enemies);
        }

        private void CreateEnemys(int amount)
        {
            float minCountLiveTime = 2f;
            float maxCountLiveTime = 10;

            for (int i = 0; i < amount; i++)
            {
                Enemy enemy = new Enemy(Random.Range(minCountLiveTime, maxCountLiveTime));

                _enemies.Add(enemy);
            }
        }
    }
}
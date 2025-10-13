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

        private TimerService _timerService;

        private CreaterEnemyWithCondition _createrEnemy;
        private EnemyService _enemyService;


        private Updater _updater;

        private void Awake()
        {
            _updater = new Updater();

            InitWallet();

            InitTimerService();

            InitEnemies();
        }

        private void Update()
            => _updater.UpdateLogic(Time.deltaTime);

        private void InitWallet()
            => _coinsView.Initialize(new Wallet());

        private void InitTimerService()
        {
            _timerService = new TimerService(_duration);

            _timerView.Initialize(_timerService);
            _sliderBarView.Initialize(_timerService);
            _heartBarView.Initialize(_timerService);

            _updater.AddUpadateble(_timerService);
        }

        private void InitEnemies()
        {
            _createrEnemy = new CreaterEnemyWithCondition(new EnemyService(5), _updater);
        }
    }
}
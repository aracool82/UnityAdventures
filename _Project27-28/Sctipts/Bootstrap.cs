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
        
        [SerializeField] private Timer _timer;
        [SerializeField] private TimerView _timerView;
        [SerializeField] private float _duration = 10;
        
        [SerializeField] private SliderBarView _sliderBarView;
        [SerializeField] private HeartBarView _heartBarView;

        [SerializeField] private EnemySevice _enemyService;
        
        private List<Enemy> _enemies = new ();
        private Updater _updater;
        
        private void Awake()
        {
            _updater = new Updater();
            
            _coinsView.Initialize(new Wallet());
            
            //------------------------------------------
            _timer.Initialize(new TimerService(_duration));
            _timerView.Initialize(_timer);
            
            _sliderBarView.Initialize(_timer);
            _heartBarView.Initialize(_timer);
            //-------------------------------------------
            int enemyCount = 5;
            CreateEnemys(enemyCount);
            //_enemyService.Initialize(_enemies);
        }

        private void Update()
        {
            _updater.UpdateLogic(Time.deltaTime);
            // _timer.UpdateLogic(Time.deltaTime);
            //
            // foreach (Enemy enemy in _enemies)
            //     enemy.UpdateLogic();
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
using System;
using System.Collections;
using UnityEngine;

namespace _Project31.Scripts
{
    public class GameCycle : IDisposable
    {
        private GameMode _gameMode;
        private Hero _hero;
        private HeroSpawner _heroSpawner;
        private HeroConfig _heroConfig;

        private ProjectileConfig _projectileConfig;

        private ConditionsFabric _conditionsFabric;
        private MonoBehaviour _contextMonoBehaviour;

        private EnemyConfig _enemyConfig;
        private EnemySpawner _enemySpawner;
        private RuleConfig _ruleConfig;
        
        private ConfirmPopup _confirmPopup;
        private TimerExample _timer;

        public GameCycle(MonoBehaviour contextMonoBehaviour,ConfirmPopup confirmPopup)
        {
            _contextMonoBehaviour = contextMonoBehaviour;
            _confirmPopup = confirmPopup;
            _timer = new TimerExample(contextMonoBehaviour,10);
        }

        public void Update(float deltaTime)
        {
            _gameMode?.Update(deltaTime);
        }

        public void Launch()
        {
            Prepare();
        }

        private void Prepare()
        {
            LoadConfigs();

            _heroSpawner = new HeroSpawner();
            _hero = _heroSpawner.Spawn(_heroConfig, new ProjectileSpawner(), _projectileConfig);
            _gameMode = new GameMode(_enemySpawner);

            _contextMonoBehaviour.StartCoroutine(Restart());

        }

        private void InitCondition()
        {
            Condition conditionDefeat = null;
            Condition conditionWin = null;

            _ruleConfig.SetRandomTypes();
            _conditionsFabric = new ConditionsFabric();

            if (_ruleConfig.TypeDefeat == TypeDefeat.HeroDead)
            {
                conditionDefeat = _conditionsFabric.Create(() =>
                        _hero.IsDead,
                    "Hero id dead");
            }
            else if (_ruleConfig.TypeDefeat == TypeDefeat.SpawedEnemys)
            {
                conditionDefeat = _conditionsFabric.Create(() =>
                        _enemySpawner.EnemiesCount == _enemyConfig.MaxEnemyCount,
                    "The enemies have captured");
            }

            TimerExample timerExample = new TimerExample(_contextMonoBehaviour, 15);

            if (_ruleConfig.TypeWin == TypeWin.TimeToWin)
            {
                conditionWin = _conditionsFabric.Create(() =>
                        _timer.IsProcess == false && _hero.IsDead == false,
                    "Time is over");

            }
            else if (_ruleConfig.TypeWin == TypeWin.KilledEnemys)
            {
                conditionWin = _conditionsFabric.Create(() => _enemySpawner.KilledEnemies == 2, "KILLED ALL ENEMIES");
            }

            _gameMode.SetConditionsFor(conditionWin, conditionDefeat);

            _gameMode.Win += OnWin;
            _gameMode.Defeat += OnDefeat;
        }

        private void LoadConfigs()
        {
            _enemySpawner = new EnemySpawner(Resources.Load<EnemyConfig>("EnemyConfig"));
            _projectileConfig = Resources.Load<ProjectileConfig>("ProjectileConfig");
            _heroConfig = Resources.Load<HeroConfig>("HeroConfig");
            _enemyConfig = Resources.Load<EnemyConfig>("EnemyConfig");
            _ruleConfig = Resources.Load<RuleConfig>("RuleConfig");
        }

        private IEnumerator Restart()
        {
            InitCondition();
            
            _confirmPopup.Show();
            KeyCode key = KeyCode.Escape;
            _confirmPopup.SetMessage($"Press {key} to Start...");
            yield return _confirmPopup.WaitConfifm(key);
           
            _confirmPopup.Hide();
            
            _gameMode.Start();

            if(_ruleConfig.TypeWin == TypeWin.TimeToWin)
                _timer.Start();
        }

        private void OnDefeat(string message)
        {
            Debug.Log(message);
            Dispose();
            _contextMonoBehaviour.StartCoroutine(Restart());
        }

        private void OnWin(string message)
        {
            Debug.Log(message);
            Dispose();
            _contextMonoBehaviour.StartCoroutine(Restart());
        }

        public void Dispose()
        {
            _gameMode.Win -= OnWin;
            _gameMode.Defeat -= OnDefeat;
        }
    }
}
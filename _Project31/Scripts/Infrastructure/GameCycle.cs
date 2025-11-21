using System;
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
        public GameCycle( MonoBehaviour contextMonoBehaviour)
        {
            _contextMonoBehaviour = contextMonoBehaviour;
        }

        public void Update(float deltaTime)
        {
            _gameMode.Update(deltaTime);
        }
        
        public void Launch()
        {
            Prepare();
        }

        private void Prepare()
        {
            _enemySpawner = new EnemySpawner(Resources.Load<EnemyConfig>("EnemyConfig"));
            _projectileConfig = Resources.Load<ProjectileConfig>("ProjectileConfig");
            _heroConfig = Resources.Load<HeroConfig>("HeroConfig");
            _enemyConfig = Resources.Load<EnemyConfig>("EnemyConfig");
            RuleConfig ruleConfig = Resources.Load<RuleConfig>("RuleConfig");
            
            _heroSpawner = new HeroSpawner();
            _hero = _heroSpawner.Spawn(_heroConfig,new ProjectileSpawner(),_projectileConfig);

            _gameMode = new GameMode(_enemySpawner);

            Condition conditionDefeat = null;
            Condition conditionWin = null;
            
            ruleConfig.SetRandomTypes();
            _conditionsFabric = new ConditionsFabric();
            
            if (ruleConfig.TypeDefeat == TypeDefeat.HeroDead)
            {
                conditionDefeat = _conditionsFabric.Create(() =>
                        _hero.IsDead,
                    "Hero id dead");
            }
            else if (ruleConfig.TypeDefeat == TypeDefeat.SpawedEnemys)
            {
                conditionDefeat = _conditionsFabric.Create(() =>
                        _enemySpawner.EnemiesCount == _enemyConfig.MaxEnemyCount,
                    "The enemies have captured");
            }

            TimerExample timerExample = new TimerExample(_contextMonoBehaviour, 15);

            if (ruleConfig.TypeWin == TypeWin.TimeToWin)
            {
                conditionWin = _conditionsFabric.Create(() => 
                        timerExample.IsProcess == false && _hero.IsDead == false,
                    "Time is over");

                timerExample.Start();
            }
            else if (ruleConfig.TypeWin == TypeWin.KilledEnemys)
            {
                conditionWin = _conditionsFabric.Create(() => _enemySpawner.KilledEnemies == 2, "KILLED ALL ENEMIES");
            }
            
            _gameMode.SetConditionsFor(conditionWin, conditionDefeat);

            _gameMode.Win += OnWin;
            _gameMode.Defeat += OnDefeat;

            _gameMode.Start();
        }
        
        private void OnDefeat(string message)
        {
            Debug.Log(message);
        }

        private void OnWin(string message)
        {
            Debug.Log(message);
        }
        
        public void Dispose()
        {
            _gameMode.Win -= OnWin;
            _gameMode.Defeat -= OnDefeat;
        }
    }
}
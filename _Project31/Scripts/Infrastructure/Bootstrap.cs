using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private HeroSpawner _heroSpawner;
        private ProjectileSpawner _projectileSpawner;
        private EnemySpawner _enemySpawner;
        private GameMode _gameMode;
        private ConditionsFabric _conditionsFabric;
        private Timer _timer;
        
        private void Awake()
        {
            _heroSpawner = new HeroSpawner();
            _projectileSpawner = new ProjectileSpawner();
            _conditionsFabric = new ConditionsFabric();
            _timer = new Timer(5);
            
            ProjectileConfig projectileConfig =  Resources.Load<ProjectileConfig>("ProjectileConfig");
            HeroConfig heroConfig = Resources.Load<HeroConfig>("HeroConfig");
            EnemyConfig enemyConfig = Resources.Load<EnemyConfig>("EnemyConfig");
            RuleConfig ruleConfig = Resources.Load<RuleConfig>("RuleConfig");
            
            Hero hero = _heroSpawner.Spawn(heroConfig,_projectileSpawner,projectileConfig);
            _enemySpawner = new EnemySpawner(enemyConfig);

            ICondition conditionDefeat = null;
            ICondition conditionWin = null;
            
            if (ruleConfig.TypeDefeat == TypeDefeat.HeroDead)
                conditionDefeat = _conditionsFabric.CreateHeroDeadCondition(hero);
            
            if(ruleConfig.TypeWin == TypeWin.TimeToWin )
            {
                conditionWin = _conditionsFabric.CreateTimeIsOverCondition(_timer, hero);
                _timer.Start();
            }
            
            _gameMode = new GameMode();
            _gameMode.SetConditions(conditionWin,conditionDefeat);
            
            _gameMode.Win += OnWin;
            _gameMode.Defeat += OnDefeat;
            
            _gameMode.Start();
            
        }
        
        private void Update()
        {
            float dTime = Time.deltaTime;
            
            _gameMode.Update(dTime);
            _timer.Update(dTime);
            _enemySpawner.Update(dTime);
        }
        private void OnDefeat(string message)
        {
            Debug.Log(message);
        }

        private void OnWin(string message)
        {
            Debug.Log(message);
        }

        private void OnDisable()
        {
            _gameMode.Win -= OnWin;
            _gameMode.Defeat -= OnDefeat;
        }
    }
}
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

            Condition conditionDefeat = null;
            Condition conditionWin = null;
            
            if (ruleConfig.TypeDefeat == TypeDefeat.HeroDead)
            {
                conditionDefeat = _conditionsFabric.Create
                (() =>
                        hero.IsDead,
                    "Hero id dead");
            }
            else if (ruleConfig.TypeDefeat == TypeDefeat.SpawedEnemys)
            {
                conditionDefeat = _conditionsFabric.Create(() =>
                        _enemySpawner.EnemiesCount == enemyConfig.MaxEnemyCount,
                    "The enemies have captured");
            }
                
            if(ruleConfig.TypeWin == TypeWin.TimeToWin )
            {
                conditionWin = _conditionsFabric.Create(() =>_timer.MaxTime.Value -_timer.CurrentTime.Value < 0.01 && hero.IsDead == false,
                    "Time is over");
                
                _timer.Start();
            }
            else if (ruleConfig.TypeWin == TypeWin.KilledEnemys)
            {
                conditionWin = _conditionsFabric.Create(() => _enemySpawner.KilledEnemies == 2, "KILLED ALL ENEMIES");
            }
            
            _gameMode = new GameMode(_enemySpawner);
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
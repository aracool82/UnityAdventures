using UnityEngine;

namespace _Project_L1
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private CoroutinePerformer _coroutinePerformerPrefab;
        [SerializeField] private GameMenu _gameMenu;

        private ICoroutinePerformer _coroutinePerformer;
        private GameCycle _gameCycle;
        private LevelConfig _levelConfig;
        
        private void Awake()
        {
            _levelConfig = Resources.Load<LevelConfig>("Configs/LevelConfig");
            _coroutinePerformer = Instantiate(_coroutinePerformerPrefab);
            
            _gameCycle = new GameCycle(_gameMenu,_levelConfig,_coroutinePerformer);
            _gameCycle.Start();
        }
    }
}
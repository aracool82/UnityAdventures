using _Project_L1.Scripts.Services;
using _Project_L1.Scripts.Utils.AssetManagement;
using _Project_L1.Scripts.Utils.CoroutineManagement;
using UnityEngine;

namespace _Project_L1.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Canvas _mainCanvas;

        private ResourcesLoader _resourcesLoader;
        private ICoroutinePerformer _coroutinePerformer;

        private GameMenu _gameMenu;
        private GameCycle _gameCycle;
        private LevelConfig _levelConfig;
        private ModeFactory _modeFactory;

        private void Awake()
        {
            _resourcesLoader =
                CreateResourcesLoader(); //инициализирован должен быть первым, иначе не будут загружатся Префабы

            _coroutinePerformer = CreateCoroutinePerformer();

            _levelConfig = CreateLevelConfig();

            _gameMenu = CreateGameMenu();

            _modeFactory = CreateModeFactory();

            _gameCycle = CreateGameCycle();
            _gameCycle.Start();
        }

        private GameCycle CreateGameCycle()
            => new GameCycle(_gameMenu, _levelConfig, _modeFactory, _coroutinePerformer);

        private static ModeFactory CreateModeFactory()
            => new ModeFactory();

        private LevelConfig CreateLevelConfig()
            => _resourcesLoader.Load<LevelConfig>("Configs/LevelConfig");

        private GameMenu CreateGameMenu()
        {
            GameMenu gameMenu = _resourcesLoader.Load<GameMenu>("Prefabs/Menu");
            _gameMenu.Initialize(new ReadInput(), _coroutinePerformer);
            return Instantiate(gameMenu, _mainCanvas.transform);
        }


        private ResourcesLoader CreateResourcesLoader()
            => new ResourcesLoader();

        private CoroutinePerformer CreateCoroutinePerformer()
        {
            CoroutinePerformer coroutinePerformerPrefab =
                _resourcesLoader.Load<CoroutinePerformer>("Prefabs/CoroutinePerformer");
            return Instantiate(coroutinePerformerPrefab);
        }
    }
}
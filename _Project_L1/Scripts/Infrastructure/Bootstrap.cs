using System;
using System.Collections;
using System.Collections.Generic;
using _Project_L1.Scripts.Services;
using _Project_L1.Scripts.Utils.AssetManagement;
using _Project_L1.Scripts.Utils.CoroutineManagement;
using UnityEngine;

namespace _Project_L1.Scripts.Infrastructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Canvas _mainCanvas;
        public event Action<string> ConfigsLoaded;
        
        private ResourcesAssetLoader _resourcesAssetLoader;
        private ICoroutinePerformer _coroutinePerformer;
        
        private GameMenu _gameMenu;
        private GameCycle _gameCycle;
        private LevelConfig _levelConfig;
        private ModeFactory _modeFactory;
        private LoadingEmulate _loadingEmulate;
        
        private void Awake()
        {
            _loadingEmulate = new LoadingEmulate();
            //StartCoroutine(ProcessStart()); 
            //StartCoroutine(Start()); 
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private IEnumerator  Start()
        {
            yield return _loadingEmulate.Simulate(5);
            Debug.Log("Loading complete!");
            yield return null;
        }

        private IEnumerator ProcessStart()
        {
            _resourcesAssetLoader = CreateResourcesLoader(); 
            //инициализирован должен быть первым,
            //иначе не будут загружаться Префабы

            _coroutinePerformer = CreateCoroutinePerformer();

            _levelConfig = CreateLevelConfig();

            _gameMenu = CreateGameMenu();

            _modeFactory = CreateModeFactory();

            _gameCycle = CreateGameCycle();
            _gameCycle.Start();
            yield return null;
        }

        private GameCycle CreateGameCycle()
            => new GameCycle(_gameMenu, _levelConfig, _modeFactory, _coroutinePerformer);

        private static ModeFactory CreateModeFactory()
            => new ModeFactory();

        private LevelConfig CreateLevelConfig()
            => _resourcesAssetLoader.Load<LevelConfig>("Configs/LevelConfig");

        private GameMenu CreateGameMenu()
        {
            GameMenu gameMenu = _resourcesAssetLoader.Load<GameMenu>("Prefabs/Menu");
            _gameMenu.Initialize(new ReadInput(), _coroutinePerformer);
            return Instantiate(gameMenu, _mainCanvas.transform);
        }


        private ResourcesAssetLoader CreateResourcesLoader()
            => new ResourcesAssetLoader();

        private CoroutinePerformer CreateCoroutinePerformer()
        {
            CoroutinePerformer coroutinePerformerPrefab =
                _resourcesAssetLoader.Load<CoroutinePerformer>("Prefabs/CoroutinePerformer");
            return Instantiate(coroutinePerformerPrefab);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using _Project_L1.Scripts.Utils.AssetManagement;
using UnityEngine;

namespace _Project_L1.Scripts.Utils.ConfigsManagement
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetLoader _resourcesAsset;

        private readonly Dictionary<Type, string> _configsResourcesPaths = new()
        {
        };

        public IEnumerator LoadAsync(Action<Dictionary<Type, string>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new();

            foreach (var configResourcePath in _configsResourcesPaths)
            {
                ScriptableObject config = _resourcesAsset.Load<ScriptableObject>(configResourcePath.Value);
                loadedConfigs.Add(configResourcePath.Key, config);
                yield return null;
            }

            //onConfigsLoaded?.Invoke(loadedConfigs); // TODO
        }
    }
}
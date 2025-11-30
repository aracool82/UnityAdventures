using UnityEngine;

namespace _Project_L1.Scripts.Utils.AssetManagement
{
    public class ResourcesLoader
    {
        public T Load<T>(string resourcePath) where T : Object
            => Resources.Load<T>(resourcePath);
    }
}
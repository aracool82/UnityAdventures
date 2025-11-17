using Unity.VisualScripting;
using UnityEngine;

namespace _Project31.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        private HeroSpawner _heroSpawner;
        
        private void Awake()
        {
            _heroSpawner = new HeroSpawner();
            HeroConfig heroConfig = Resources.Load<HeroConfig>("HeroConfig");
            Hero hero = _heroSpawner.Spawn(heroConfig);
        }
    }
}
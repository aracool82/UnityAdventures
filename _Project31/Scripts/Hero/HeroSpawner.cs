using UnityEngine;

namespace _Project31.Scripts
{
    public class HeroSpawner 
    {
        private Hero _heroPrefab;

        public HeroSpawner(Hero heroPrefab)
        {
            _heroPrefab = heroPrefab;
        }

        public void Spawn(Vector3 position)
        {
            Hero hero = Object.Instantiate(_heroPrefab, position, Quaternion.identity);
            //hero.Initialize();
        }
    }
}
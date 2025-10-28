using UnityEngine;

namespace _Project29_30.Scripts
{
    public class GenericExample : MonoBehaviour
    {
        [SerializeField] private Apple[] _apples;
        [SerializeField] private Banana[] _bananas;

        [SerializeField] private Storage<Apple> _appleStorage;
        private Storage<Banana> _bananasStorage;

        private void Awake()
        {
            _appleStorage = new Storage<Apple>();

            foreach (Apple appple in _apples)
                _appleStorage.Add(appple);
            
            _bananasStorage = new Storage<Banana>();

            foreach (Banana banana in _bananas)
                _bananasStorage.Add(banana);
        }

        private void Update()   
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Apple apple = _appleStorage.GetRandom();

                if (apple == null)
                    return;

                _appleStorage.Remove(apple);
                apple.ChangeScaleTo(new Vector3(2f, 2f, 2f));
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Banana banana = _bananasStorage.GetRandom();

                if (banana == null)
                    return;
                
                _bananasStorage.Remove(banana);
                banana.Eat();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                 Debug.Log($"Позиция рандомного яблока - {_appleStorage.GetRandomPosition()}");
        }
    }
}
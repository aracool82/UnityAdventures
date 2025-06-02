using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class DirectionGenerator
    {
        private float _timer;
        private float _timeToChange;
        private float _range;
        
        public DirectionGenerator(float timeToChange, float range)
        {
            _timeToChange = timeToChange;
            _range = range;
            Direction = Vector3.zero;
        }

        public Vector3 Direction { get; private set; }

        public void Update(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer >= _timeToChange)
            {
                Direction = new Vector3(0,Mathf.Round(Random.Range(0, _range)), 0);
                _timer = 0;
            }
        }
    }
}
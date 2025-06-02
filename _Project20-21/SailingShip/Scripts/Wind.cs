using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {

        private DirectionGenerator _directionGenerator;
        private Rotator _rotator;

        private void Awake()
        {
            _directionGenerator = new DirectionGenerator(3, 360);
            _rotator = new Rotator(transform, 500);
        }

        private void Update()
        {
            _directionGenerator.Update(Time.deltaTime);
            _rotator.Rotation(Time.deltaTime, _directionGenerator.Direction);
        }
    }
}
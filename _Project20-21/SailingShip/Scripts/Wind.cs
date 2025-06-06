using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private float _rotationSpeed ;
        [SerializeField] private float _timeToChange;
        [SerializeField , Range(180,360)] private float _rangeAngle;
        
        private DirectionGenerator _directionGenerator;
        private Follower _follower;
        private RotatorWithDirection _rotator;

        public float Power => Mathf.Clamp01(Vector3.Dot(transform.forward, _ship.SailDirection));

        private void Awake()
        {
            _directionGenerator = new DirectionGenerator(_timeToChange, _rangeAngle);
            _follower = new Follower(transform);
            _rotator = new RotatorWithDirection(transform, _rotationSpeed);
        }

        private void Update()
        {
            _follower.FollowTo(_ship.transform, new Vector3(0, 3, 0));
            _directionGenerator.Update(Time.deltaTime);
            _rotator.Rotate(_directionGenerator.Direction);
        }
    }
}
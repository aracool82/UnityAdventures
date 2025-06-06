using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private Ship _ship;

        private DirectionGenerator _directionGenerator;
        private RotatorBase _rotatorBase;
        private Follower _follower;

        //public float Power => Mathf.Clamp01(Vector3.Dot(transform.forward, _ship.SailDirection));

        private void Awake()
        {
            _directionGenerator = new DirectionGenerator(2, 360);
            _rotatorBase = new RotatorBase(transform, 500);
            _follower = new Follower(transform);
        }

        private void Update()
        {
            _follower.FollowTo(_ship.transform, new Vector3(0, 3, 0));
           
            _directionGenerator.Update(Time.deltaTime);
            _rotatorBase.Ratate(_directionGenerator.Direction);
        }
    }
}
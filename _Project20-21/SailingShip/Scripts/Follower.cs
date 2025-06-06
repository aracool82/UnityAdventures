using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Follower
    {
        private Transform _source;

        public Follower(Transform source)
            =>_source = source;

        public void FollowTo(Transform target, Vector3 offsetY)
           =>_source.position = target.position + offsetY;
    }
}
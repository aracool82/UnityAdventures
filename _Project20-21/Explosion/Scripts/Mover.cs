using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Mover
    {
        private Transform _source;

        public Mover(Transform source)
            =>_source = source;

        public void MoveTo(Vector3 position)
            =>_source.position = position;
    }
}
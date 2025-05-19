using System.Collections.Generic;
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _power ;
        [SerializeField] private float _upwardsModifier;

        public void Explode(Vector3 position,List<IExploded> boxes )
        {
            foreach (IExploded box in boxes)
              box.Rigidbody.AddExplosionForce(_power, position, _radius, _upwardsModifier, ForceMode.Impulse);
        }
    }
}
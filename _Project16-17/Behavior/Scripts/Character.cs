using System;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Mover _mover;

        public void Move(Vector3 direction)
            => _mover.Move(direction);
    }
}
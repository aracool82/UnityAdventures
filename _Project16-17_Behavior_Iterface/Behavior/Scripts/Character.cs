using System;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Character : MonoBehaviour,IMoveble
    {
        [SerializeField] private float _speed;
        
        private Mover _mover;
        private CharacterInput _characterInput;
        
        private void Awake()
        { 
            _characterInput = new CharacterInput(this);
            _mover = new Mover(transform, _speed);
        }

        private void Update()
            =>_characterInput.Update();

        public void Move(Vector3 direction)
            => _mover.MoveToDirection(direction);
    }
}
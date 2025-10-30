using System;
using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Elf : Enemy
    {
        [SerializeField] private Vector3 _position;
        [SerializeField] private Quaternion _rotation;
        [SerializeField] private string _name;
    }
}
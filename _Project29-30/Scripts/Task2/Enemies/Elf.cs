using UnityEngine;

namespace _Project29_30.Scripts.Task2
{
    public class Elf : Enemy
    {
         private Vector3 _position;
         private Quaternion _rotation;
         private string _name;
        
         public void Initialize(Vector3 position, Quaternion rotation, string name)
        {
            _position = position;
            _rotation = rotation;
            _name = name;
        }
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace _Project_L1.Scripts.Services
{
    public interface IReadInputService
    {
        event Action<KeyCode> PresedKey;
        IEnumerator WaitPressFor(KeyCode keyCode);
    }
}
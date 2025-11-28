using System;
using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public interface IReadInput
    {
        event Action<KeyCode> PresedKey;
        public bool IsPressed { get; }
        IEnumerator WaitPressFor(KeyCode keyCode);
    }
}
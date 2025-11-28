using System;
using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public interface IReadInput
    {
        event Action<KeyCode> PresedKey;
        IEnumerator WaitPressFor(KeyCode keyCode);
    }
}
using System;
using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public class ReadInput : IReadInput
    {
        public event Action<KeyCode> PresedKey;

        public IEnumerator WaitPressFor(KeyCode keyCode)
        {
            Debug.Log($"Wait for {keyCode} key");
            yield return new WaitWhile(() => Input.GetKeyDown(keyCode) == false);
            Debug.Log($"Key {keyCode} pressed.");
            PresedKey?.Invoke(keyCode);
        }
    }
}
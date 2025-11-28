using System;
using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public class ReadInput : IReadInput
    {
        public event Action<KeyCode> PresedKey;
        public bool IsPressed { get; private set; } = false;

        public IEnumerator WaitPressFor(KeyCode keyCode)
        {
            Debug.Log($"Wait for {keyCode} key");
            yield return new WaitWhile(() => Input.GetKeyDown(keyCode) == false);
            IsPressed = true;
            Debug.Log($"Key {keyCode} pressed.");
            PresedKey?.Invoke(keyCode);
        }
    }
}
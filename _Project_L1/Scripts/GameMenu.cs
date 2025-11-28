using System;
using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public class GameMenu : MonoBehaviour
    {
        private IReadInput _readInput;
        private bool _isSelectedMode;
        private ICoroutinePerformer _coroutinePerformer;
        public SequenceTypes SequenceType { get; private set; } = SequenceTypes.None;

        public void Initialize(IReadInput readInput, ICoroutinePerformer coroutinePerformer)
        {
            _readInput = readInput;
            _coroutinePerformer = coroutinePerformer;

            _readInput.PresedKey += OnPresedKey;
            _isSelectedMode = false;
        }

        public IEnumerator ShowWithWait()
        {
            gameObject.SetActive(true);
            WaitUntil waitForChoice = new WaitUntil(() => _isSelectedMode);

            Debug.Log("Waiting for USER choice : ");
            _coroutinePerformer.Perform(_readInput.WaitPressFor(KeyCode.Alpha1));
            _coroutinePerformer.Perform(_readInput.WaitPressFor(KeyCode.Alpha2));

            yield return waitForChoice;
            Hide();
        }

        private void OnPresedKey(KeyCode key)
        {
            switch (key)
            {
                case KeyCode.Alpha1:
                    SequenceType = SequenceTypes.Numbers;
                    break;

                case KeyCode.Alpha2:
                    SequenceType = SequenceTypes.Chars;
                    break;

                default:
                    throw new ArgumentException("Invalid key");
            }

            _isSelectedMode = true;
            Debug.Log($"Selected Mod : {SequenceType}");
        }

        private void Hide()
            => gameObject.SetActive(false);

        private void OnDestroy()
            => _readInput.PresedKey -= OnPresedKey;
    }
}
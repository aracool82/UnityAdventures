using System.Collections;
using UnityEngine;

namespace _Project_L1
{
    public class GameMenu : MonoBehaviour
    {
        private Coroutine _coroutine;
        public SequenceTypes SequenceType { get; private set; } = SequenceTypes.None;

        public void Show()
        {
            gameObject.SetActive(true);

            // if (_coroutine == null)
            //     _coroutine = StartCoroutine(GetMode());
        }
        
        public void Hide()
            => gameObject.SetActive(false);

        public IEnumerator WaitSelectedMod()
        {
            yield return new WaitUntil(
                () => Input.GetKeyDown(KeyCode.Alpha1) ||
                      Input.GetKeyDown(KeyCode.Alpha2));

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SequenceType = SequenceTypes.Numbers;
                yield break;
            }

            SequenceType = SequenceTypes.Chars;
        }
    }
}
using System.Collections;
using TMPro;
using UnityEngine;

namespace _Project_L1
{
    public class ConfirmPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        public void Show()
            => gameObject.SetActive(true);

        public void Hide()
            => gameObject.SetActive(false);
        
        public void SetMessage(string message)
            => text.text = message;
        
        public IEnumerator WaitConfifm(KeyCode key)
        {
            yield return new WaitWhile(() => Input.GetKeyDown(key) == false);
        }
    }
}
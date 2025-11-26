using System.Collections;
using TMPro;
using UnityEngine;

namespace _Project_L1
{
    public class ConfirmPopup : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        private SequenceTypes _sequenceType;

        private bool IsPressedAlpha1 => Input.GetKeyDown(KeyCode.Alpha1);
        private bool IsPressedAlpha2 => Input.GetKeyDown(KeyCode.Alpha2);
        
        public void Show()
            => gameObject.SetActive(true);

        public void Hide()
            => gameObject.SetActive(false);
        
        public void SetMessage(string message)
            => text.text = message;
        
        public IEnumerator WaitConfirm(KeyCode key1, KeyCode key2)
        {
            bool isPessed = false;
            
            while(isPessed == false)
            {
                if (Input.GetKeyDown(key1) || Input.GetKeyDown(key2))
                {   
                    if(Input.GetKeyDown(key1))
                        _sequenceType = SequenceTypes.Numbers;
                    else if (Input.GetKeyDown(key2))
                        _sequenceType = SequenceTypes.Chars;
                    
                    isPessed = true;
                }
                
                yield return null;
            }
        }
    }
}
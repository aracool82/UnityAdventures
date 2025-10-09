using UnityEngine;

namespace _Project27_28.Scripts
{
    public class TestAwakeEnabled:MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Awake " + gameObject.name);
        }

        private void OnEnable()
        {
            Debug.Log("OnEnable "+ gameObject.name);
        }

        private void OnDisable()
        {
            Debug.Log("OnDisable "+ gameObject.name);
        }

        private void OnDestroy()
        {
            Debug.Log("OnDestroy "+ gameObject.name);
        }
    }
}
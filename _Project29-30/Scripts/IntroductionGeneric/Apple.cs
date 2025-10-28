using UnityEngine;

namespace _Project29_30.Scripts
{
    public class Apple : MonoBehaviour
    {
        public void ChangeScaleTo(Vector3 scale)
            =>transform.localScale = scale;
    }
}
using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class TestLerp: MonoBehaviour
    {
        private float minValue = 0;
        private float maxValue = 90;        
        [SerializeField,Range(0,1f)]private float _angle;

        private void Update()
        {
            float angle = Mathf.Lerp(minValue,maxValue, _angle);
            transform.position = Vector3.Lerp(Vector3.zero, new Vector3(0,0,4),_angle);
            Debug.Log(angle);
        }
    }
}
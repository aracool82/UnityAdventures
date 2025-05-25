using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    public class Wind : MonoBehaviour
    {
        [SerializeField] private Ship _ship;

        [SerializeField] private float _changeDirectionTime;
        private float _time;

        public Vector3 Direction => transform.forward;

        private void Update()
        {
            transform.position = new Vector3(_ship.transform.position.x, transform.position.y, _ship.transform.position.z);
            
            _time += Time.deltaTime;

            if (_time >= _changeDirectionTime)
            {
                _time = 0;
                transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(0f, 180), 0));
            }
        }
    }
}
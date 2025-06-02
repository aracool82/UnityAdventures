using UnityEngine;

namespace _Project20_21.SailingShip.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ship : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                transform.rotation = Quaternion.identity;
        }

    }
}
using UnityEngine;

namespace _Project20_21.Explosion.Scripts
{
    public class Selector : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
            => _camera = Camera.main;

        public bool TrySelect(out Box box)
        {
            box = null;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Box selectableBox))
                {
                    box = selectableBox;
                    return true;
                }
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            // if (Application.isPlaying)
            // {
            //     Gizmos.color = Color.red;
            //     _camera = Camera.main;
            //     Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //     Gizmos.DrawRay(_camera.transform.position, ray.direction * 10f);
            //     Gizmos.DrawCube(new Vector3(0f, 0f, 0f), Vector3.one);
            //     //Gizmos.DrawIcon();}
            // }
        }
    }
}
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project24_25.NavMesh2
{
    public class MouseView : MonoBehaviour
    {
        private const int LeftMouseButton = 0;
        private const string GroundLayer = "Ground";

        [SerializeField] private AudioClip _audioClipClick;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _clickEffectParticlce;
        [SerializeField] private LayerMask _groundLayerMask;

        private ClickGroundHandler _clickGroundHandler;
        private Camera _camera;

        private bool IsLeftMouseButtonClick => Input.GetMouseButtonDown(LeftMouseButton);
        private bool IsUiClicked => EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();

        private void Awake()
        {
            _clickGroundHandler = new ClickGroundHandler(_groundLayerMask, transform);
            _camera = Camera.main;
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (IsLeftMouseButtonClick && IsUiClicked == false)
            {
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    _clickEffectParticlce.transform.position = hit.point + new Vector3(0, 0.1f, 0);
                    _clickEffectParticlce.Play();
                    _audioSource.PlayOneShot(_audioClipClick);
                }
            }
        }
    }
}
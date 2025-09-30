using UnityEngine;
using UnityEngine.EventSystems;

namespace _Project24_25.NavMesh2
{
    public class MouseView : MonoBehaviour
    {
        private const int LeftMouseButton = 0;
        
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private ParticleSystem _clickEffectParticle;
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
                    _clickEffectParticle!.transform.position = hit.point + new Vector3(0, 0.1f, 0);
                    _clickEffectParticle!.Play();
                    _audioManager!.PlayOneShotClip(_clip);
                }
            }
        }
    }
}
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class ScalePulse : MonoBehaviour
    {
        [SerializeField] private Renderer _targetRenderer; // укажи MeshRenderer объекта
        [SerializeField] private string propertyName = "_ScaleFactor"; 
        [SerializeField] private float minScale = 1.0f;
        [SerializeField] private float maxScale = 1.5f;
        [SerializeField] private float duration = 1f; // полный цикл (туда-обратно)

        private Material[] _materials;

        void Start()
        {
            _materials = _targetRenderer.materials;
        }

        void Update()
        {
            // PingPong идёт от 0 до 1 и обратно за duration/2
            float t = Mathf.PingPong(Time.time, duration / 10f) / (duration / 10f);
            float scale = Mathf.Lerp(minScale, maxScale, t);
            
            foreach (Material material in _materials)
                material.SetFloat(propertyName, scale);
        }
    }
}
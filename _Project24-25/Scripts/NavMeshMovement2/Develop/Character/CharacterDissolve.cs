using System.Collections;
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class CharacterDissolve : MonoBehaviour
    {
        private const string PropertyEdge = "_Edge";

        [SerializeField] private SkinnedMeshRenderer[] _meshRenderers;
        [SerializeField] private AgentCharacter _character;
        
        private float _time = 2f;

        public void Run()
        {
            StartCoroutine(ProcessDissolve());
        }

        private IEnumerator ProcessDissolve()
        {
            float elapsedTime = 0;
            
            while (elapsedTime <= _time)
            {
                elapsedTime += Time.deltaTime;
                float value = Mathf.Clamp01(elapsedTime / _time);
                SetFloatFor(_meshRenderers, PropertyEdge, value);
                yield return null;
            }
            
            _character.gameObject.SetActive(false);
        }

        private void SetFloatFor(SkinnedMeshRenderer[] meshRenderers, string property, float value)
        {
            foreach (SkinnedMeshRenderer meshRenderer in meshRenderers)
                meshRenderer.material.SetFloat(property, value);
        }
    }
}
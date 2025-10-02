using System.Collections;
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class CharacterDissolve : MonoBehaviour
    {
        private const string PropertyEdge = "_Edge";
        private const string PropertyEmission = "_Emission";

        [SerializeField] private SkinnedMeshRenderer[] _meshRenderers;
        [SerializeField] private AgentCharacter _character;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _desolveMaterial;

        private float _timeDesolve = 2f;
        private float _timeEffectDamage = 0.9f;

        private void Start()
        {
            SetMaterialFor(_meshRenderers, _defaultMaterial);
        }

        public void Run()
        {
            SetMaterialFor(_meshRenderers, _desolveMaterial);
            StartCoroutine(ProcessDissolve());
        }

        public void AplyEffectDamge()
        {
            StartCoroutine(ProcessAplyEffectDamge());
        }

        private IEnumerator ProcessAplyEffectDamge()
        {
            float elapsedTime = 0;

            while (elapsedTime <= _timeEffectDamage)
            {
                elapsedTime += Time.deltaTime;
                float value = Mathf.Clamp01(elapsedTime / _timeEffectDamage);
                SetFloatFor(_meshRenderers, PropertyEmission, value);
                yield return null;
            }

            SetFloatFor(_meshRenderers, PropertyEmission, 0);
        }

        private IEnumerator ProcessDissolve()
        {
            float elapsedTime = 0;

            while (elapsedTime <= _timeDesolve)
            {
                elapsedTime += Time.deltaTime;
                float value = Mathf.Clamp01(elapsedTime / _timeDesolve);
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

        private void SetMaterialFor(SkinnedMeshRenderer[] meshRenderers, Material material)
        {
            foreach (SkinnedMeshRenderer meshRenderer in _meshRenderers)
                meshRenderer.material = material;
        }
    }
}
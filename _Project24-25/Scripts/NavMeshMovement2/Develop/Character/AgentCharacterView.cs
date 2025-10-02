using TMPro;
using UnityEngine;

namespace _Project24_25.NavMesh2
{
    public class AgentCharacterView : MonoBehaviour
    {
        private const float FullPersent = 100;
        private const string InjeredLayerName = "InjeredLayer";
        
        private readonly int IsRuningKey = Animator.StringToHash("IsRun");
        private readonly int IsJumpProcessKey = Animator.StringToHash("IsJumpProcess");
        
        private readonly int IsDeadKey = Animator.StringToHash("IsDead");
        private readonly int IsTakeDamageKey = Animator.StringToHash("TakeDamage");

        [SerializeField] private AgentCharacter _character;
        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _criticalPersent = 30;
        [SerializeField] private CharacterDissolve _shaderEffect;

        private float _currentPersent;
        private int _injeredLayerIndex;
        private float _maxWeight = 1;
        
        private void Start()
        {
            _injeredLayerIndex = _animator.GetLayerIndex(InjeredLayerName);
        }

        private void Update()
        {
            _currentPersent = _character.Health / (_character.MaxHealth / FullPersent);
            _text.text = "HP : " + _character.Health.ToString() + "\n % : " + _currentPersent.ToString("0.0");
            
            if(IsCriticalPersent())
            {
                _text.color = Color.red;
                _animator.SetLayerWeight(_injeredLayerIndex, _maxWeight);
            }
            
            _animator.SetBool(IsJumpProcessKey,_character.InJumpProcess);
            
            if (_character.CurrentVelocity.normalized != Vector3.zero)
                SetAnimationRun();
            else
                SetAnimationIdle();
        }
        
        private bool IsCriticalPersent()
            => _currentPersent <= _criticalPersent;
        
        private void SetAnimationRun()
            => _animator.SetBool(IsRuningKey, true);

        private void SetAnimationIdle()
            => _animator.SetBool(IsRuningKey, false);

        public void SetAnimationTakeDamage()
        {
            if (_character.IsAlive)
            {
                _shaderEffect.AplyEffectDamge();
                _animator.SetTrigger(IsTakeDamageKey);
            }
            else
            {
                _shaderEffect.AplyEffectDamge();
                _character.StopMove();
                _animator.SetTrigger(IsDeadKey);
            }
        }
    }
}
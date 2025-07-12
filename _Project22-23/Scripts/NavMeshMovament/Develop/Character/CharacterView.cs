using TMPro;
using UnityEngine;

namespace _Project22_23.Scripts.NewNavMeshScripts
{
    public class CharacterView : MonoBehaviour
    {
        private const float FullPersent = 100;

        private readonly int IsRuningKey = Animator.StringToHash("IsRun");
        private readonly int IsDeadKey = Animator.StringToHash("IsDead");
        private readonly int IsTakeDamageKey = Animator.StringToHash("TakeDamage");

        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _criticalPersent = 30;

        private float _currentPersent;
        private int _injeredLayerIndex;
        private float _maxWeight = 1;
        
        private void Awake()
        {
            _injeredLayerIndex = _animator.GetLayerIndex("InjeredLayer");
        }

        private void Update()
        {
            _currentPersent = _character.Health / (_character.MaxHealth / FullPersent);
            _text.text = "hp : " + _character.Health.ToString() + " % : " + _currentPersent.ToString("0.0");
            
            if(IsCriticalPersent())
                _animator.SetLayerWeight(_injeredLayerIndex,_maxWeight);
            
            if (_character.IsMoved)
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
                _animator.SetTrigger(IsTakeDamageKey);
            else
                _animator.SetTrigger(IsDeadKey);
        }
    }
}
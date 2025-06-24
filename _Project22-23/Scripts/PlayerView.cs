using TMPro;
using UnityEngine;

namespace _Project22_23.Scripts
{
    public class PlayerView : MonoBehaviour
    {
        private const float FullPersent = 100f; 
        private readonly int KeyIsRun = Animator.StringToHash("IsRun");
        private readonly int KeyDead = Animator.StringToHash("IsDead");
        private readonly int KeyTakeDamage = Animator.StringToHash("TakeDamage");

        [SerializeField] private Player _player;

        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Animator _animator;

        private int _injeredIndexLayer;
        private float _changeLayerPersent = 30;
        private float _maxWeighLayer = 1f;

        private void Awake()
        {
            _injeredIndexLayer = _animator.GetLayerIndex("InjeredLayer");
        }

        private void Update()
        {
            float persentOfDamage = GetPersentOfDamage();
            _text.text = $"HP / {_player.Health.ToString("0")} % - {persentOfDamage}";

            if (persentOfDamage <= _changeLayerPersent)
                _animator.SetLayerWeight(_injeredIndexLayer, _maxWeighLayer);

            if (_player.Velocity == Vector3.zero)
                PlayIdleAnimation();
            else
                PlayRunAnimation();
        }

        public void PlayTakeDamageAnimation()
            => _animator.SetTrigger(KeyTakeDamage);

        public void PlayDeadAnimation()
            => _animator.SetTrigger(KeyDead);

        private void PlayIdleAnimation()
            => _animator.SetBool(KeyIsRun, false);

        private void PlayRunAnimation()
            => _animator.SetBool(KeyIsRun, true);

        private float GetPersentOfDamage()
            => Mathf.Round(_player.Health / (_player.MaxHealth / FullPersent));
    }
}
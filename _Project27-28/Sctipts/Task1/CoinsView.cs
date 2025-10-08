using TMPro;
using UnityEngine;

namespace _Project27_28.Scripts
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private Storage _storage;
        
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _diamondText;
        [SerializeField] private TMP_Text _enrrgyText;

        private void OnEnable()
           => _storage.Changed += OnChanged;

        private void OnDisable()
            => _storage.Changed -= OnChanged;
        
        public void OnChanged()
        {
            _coinsText.text = _storage?.GetCoinsByType(CoinType.Coin).ToString();
            _diamondText.text = _storage?.GetCoinsByType(CoinType.Diamonds).ToString();
            _enrrgyText.text = _storage?.GetCoinsByType(CoinType.Energy).ToString();
        }
    }
}
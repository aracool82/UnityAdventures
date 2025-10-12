using TMPro;
using UnityEngine;

namespace _Project27_28.Scripts.Task1
{
    public class CoinsView : MonoBehaviour
    {
        private int _minValueCoin = 1;
        private int _maxValueCoin = 10;
        
        [SerializeField] private TMP_Text _coinsText;
        [SerializeField] private TMP_Text _diamondText;
        [SerializeField] private TMP_Text _enrrgyText;

        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.Changed += OnChanged;
        }

        private void OnDisable()
            => _wallet.Changed -= OnChanged;

        public void OnChanged()
        {
            _coinsText.text = _wallet.GetCoinsBy(coin => coin.Type == CoinType.Coin).ToString();
            _diamondText.text = _wallet.GetCoinsBy(coin => coin.Type == CoinType.Diamonds).ToString();
            _enrrgyText.text = _wallet.GetCoinsBy(coin => coin.Type == CoinType.Energy).ToString();
        }
        
        public void CreateRandomCoin()
            =>_wallet?.AddCoin(new Coin(Random.Range(_minValueCoin, _maxValueCoin), GetRandomCoinType()));

        public void RemoveRandomCoin()
            => _wallet?.RemoveRandomCoin();
        
        private CoinType GetRandomCoinType()
            => (CoinType)Random.Range(0, CoinType.GetValues(typeof(CoinType)).Length);
    }
}
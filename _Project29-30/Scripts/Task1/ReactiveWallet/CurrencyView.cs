using _Project29_30.Scripts.ReactiveGeneric_Health;
using TMPro;
using UnityEngine;

namespace _Project29_30.Scripts.Task1.ReactiveWallet
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private IReadOnlyVariable<int> _diamonds;
        private IReadOnlyVariable<int> _energys;
        private IReadOnlyVariable<int> _coins;

        public void Initialize(
            IReadOnlyVariable<int> diamonds,
            IReadOnlyVariable<int> energys,
            IReadOnlyVariable<int> coins)
        {
            _diamonds = diamonds;
            _energys = energys;
            _coins = coins;

            _diamonds.Changed += OnDiamondsChanged;
            _energys.Changed += OnEnergyChanged;
            _coins.Changed += OnCoinChanged;

            UpdateCurrencys(_diamonds.Value, _energys.Value, _coins.Value);
        }

        private void OnDestroy()
        {
            _diamonds.Changed -= OnDiamondsChanged;
            _energys.Changed -= OnEnergyChanged;
            _coins.Changed -= OnCoinChanged;
        }

        private void OnDiamondsChanged(int arg1, int newValue)
            => UpdateCurrencys(newValue, _energys.Value, _coins.Value);

        private void OnEnergyChanged(int arg1, int newValue)
            => UpdateCurrencys(_diamonds.Value, newValue, _coins.Value);


        private void OnCoinChanged(int oldValue, int newValue)
            => UpdateCurrencys(_diamonds.Value, _energys.Value, newValue);

        private void UpdateCurrencys(float diamonds, float energy, float coins)
        {
            string text = $"{CurrencyType.Diamonds} - {diamonds}\n" +
                          $"{CurrencyType.Energy}      - {energy}\n" +
                          $"{CurrencyType.Coins}        - {coins}";

            _text.text = text;
        }
    }
}
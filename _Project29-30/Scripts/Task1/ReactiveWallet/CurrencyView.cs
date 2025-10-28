using System;
using TMPro;
using UnityEngine;

namespace _Project29_30.Scripts.Task1.ReactiveWallet
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;
            _wallet.Changed += OnChanged;
            OnChanged();
        }

        private void OnDestroy()
            => _wallet.Changed += OnChanged;
        
        private void OnChanged()
        {
            int diamonds = _wallet.GetCurrencyBy(() => CurrencyType.Diamonds);
            int energy =_wallet.GetCurrencyBy(() => CurrencyType.Energy);;
            int coins = _wallet.GetCurrencyBy(() => CurrencyType.Coins);;
            
            string text = $"{CurrencyType.Diamonds} - {diamonds}\n" +
                          $"{CurrencyType.Energy}      - {energy}\n" +
                          $"{CurrencyType.Coins}        - {coins}";
            
            _text.text = text;
        }
    }
}
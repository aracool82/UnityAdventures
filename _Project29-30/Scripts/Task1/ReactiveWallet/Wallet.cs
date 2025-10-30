using System.Collections.Generic;
using System.Linq;
using _Project29_30.Scripts.ReactiveGeneric_Health;
using UnityEngine;


namespace _Project29_30.Scripts.Task1.ReactiveWallet
{
    public class Wallet
    {
        private Dictionary<CurrencyType, ReactiveVariable<int>> _currencies;

        public Wallet()
        {
            _currencies = new();

            _currencies.Add(CurrencyType.Diamonds, new ReactiveVariable<int>());
            _currencies.Add(CurrencyType.Energy, new ReactiveVariable<int>());
            _currencies.Add(CurrencyType.Coins, new ReactiveVariable<int>());
        }

        //public IReadOnlyDictionary<CurrencyType, ReactiveVariable<int>> Currencies => _currencies;
        public IReadOnlyDictionary<CurrencyType, IReadOnlyVariable<int>> Currencies
            => _currencies
                .ToDictionary(pair => pair.Key, pair => (IReadOnlyVariable<int>)pair.Value);

        public void AddCurrency(CurrencyType type)
        {
            if (_currencies.ContainsKey(type))
                _currencies[type].Value++;
        }

        public void RemoveCurrency(CurrencyType type)
        {
            if (_currencies.ContainsKey(type))
            {
                _currencies[type].Value--;

                if (_currencies[type].Value < 0)
                    _currencies[type].Value = 0;
            }
            else
            {
                Debug.Log($" Error: No {type} to remove");
            }
        }
    }
}
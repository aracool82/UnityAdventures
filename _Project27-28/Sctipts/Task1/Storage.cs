using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project27_28.Scripts.Task1
{
    public class Storage : MonoBehaviour
    {
        public event Action Changed
        {
            add => _wallet.Changed += value;
            remove => _wallet.Changed -= value;
        }

        [SerializeField] private int _maxCoins = 20;
        [SerializeField] private int _maxValueCoin = 5;
        [SerializeField] private int _minValueCoin = 1;

        private Wallet _wallet;

        public void Initialize(Wallet wallet)
        {
            _wallet = wallet;

            for (int i = 0; i < _maxCoins; i++)
                _wallet.AddCoin(CreateCoin());
        }

        public int GetCoinsByType(CoinType type)
        {
            if (_wallet.TryGetCoinsBy(coin => coin.Type == type, out List<Coin> coins))
                return coins.Count;

            return 0;
        }

        public void AddCoin()
            => _wallet.AddCoin(CreateCoin());

        public void RemoveCoin()
            => _wallet.RemoveCoin();

        private Coin CreateCoin()
            => new Coin(Random.Range(_minValueCoin, _maxValueCoin), GetRandomCoinType());

        private CoinType GetRandomCoinType()
            => (CoinType)Random.Range(0, CoinType.GetValues(typeof(CoinType)).Length);
    }
}
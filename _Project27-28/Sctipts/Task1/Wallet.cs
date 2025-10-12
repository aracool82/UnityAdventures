using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace _Project27_28.Scripts.Task1
{
    public class Wallet
    {
        public event Action Changed;

        private List<Coin> _coins = new List<Coin>();

        public void AddCoin(Coin coin)
        {
            if (coin != null)
            {
                _coins.Add(coin);
                Changed?.Invoke();
            }
        }

        public void RemoveRandomCoin()
        {
            if (_coins.Count > 0)
            {
                _coins.RemoveAt(Random.Range(0, _coins.Count));
                Changed?.Invoke();
            }
        }

        public int GetCoinsBy(Func<Coin, bool> filter)
            => _coins.Count(filter);
    }
}
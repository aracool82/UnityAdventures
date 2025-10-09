using System;
using System.Collections.Generic;

namespace _Project27_28.Scripts.Task1
{
    public class Wallet
    {
        public event Action Changed;
        
        private List<Coin> _coins = new List<Coin>();
        public int Count => _coins.Count;

        public void AddCoin(Coin coin)
        {
            if (coin != null)
            {
                _coins.Add(coin);
                Changed?.Invoke();
            }
        }

        public void RemoveCoin ()
        {
            if (_coins.Count > 0)
            {
                _coins.RemoveAt(0);
                Changed?.Invoke();
            }
        }

        public bool TryGetCoinsBy(Func<Coin, bool> filter, out List<Coin> coins)
        {
            List<Coin> result = new List<Coin>();

            foreach (Coin coin in _coins)
                if (filter.Invoke(coin))
                    result.Add(coin);
            
            coins = result;
            
            if(result.Count == 0)
                return false;
            
            return true;
        }
    }
}
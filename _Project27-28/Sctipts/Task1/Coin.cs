using UnityEngine;

namespace _Project27_28.Scripts
{
    public class Coin
    {
        public Coin(int value, CoinType type)
        {
            Value = value;
            Type = type;
        }

        public int Value { get; }
        public CoinType Type { get; }
    }
}
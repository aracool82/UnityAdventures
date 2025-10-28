using System;
using System.Collections.Generic;

using UnityEngine;

namespace _Project29_30.Scripts.Task1.ReactiveWallet
{
    public class Wallet
    {
        public event Action Changed;

        public Func<bool> Filter;//доделать
        
        private Dictionary<CurrencyType,int> _currencies ;

        public Wallet()
        {
            _currencies = new Dictionary<CurrencyType,int>();
            Filter = IsContainsElement;
        }

        public void AddCurrency(CurrencyType type)
        {
            if (_currencies.ContainsKey(type))
                _currencies[type]++;
            else
                _currencies.Add(type, 1);
            
            Changed?.Invoke();
        }

        public void RemoveCurrency(CurrencyType type)
        {
            if (_currencies.ContainsKey(type))
            {
                _currencies[type]--;
                
                if(_currencies[type] == 0)
                    _currencies.Remove(type);
                
                Changed?.Invoke();
            }
            else
            {
                Debug.Log($" Error: No {type} to remove");
            }
        }

        public int GetCurrencyBy(Func<CurrencyType> filter)
        {
            if (_currencies.ContainsKey(filter.Invoke()))
                return _currencies[filter.Invoke()];
            
            return 0;
        }
        
        public int GetCurrency(CurrencyType type)
        {
            if(_currencies.ContainsKey(type))
                return _currencies[type];
            
            return 0;
        }

        private bool IsContainsElement()
        {
            return _currencies.Count > 0;
        }
    }
}
using UnityEngine;

namespace _Project29_30.Scripts.Task1.ReactiveWallet
{
    public class WalletExample : MonoBehaviour
    {
        [SerializeField] private CurrencyView _currencyView;
        
        private Wallet _wallet;
        
        private void Awake()
        {
            _wallet = new Wallet();
            _currencyView.Initialize(_wallet);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
                _wallet.AddCurrency(CurrencyType.Diamonds);
            
            if(Input.GetKeyDown(KeyCode.Alpha2))
                _wallet.AddCurrency(CurrencyType.Energy);
            
            if(Input.GetKeyDown(KeyCode.Alpha3))
                _wallet.AddCurrency(CurrencyType.Coins);
        }
    }
}
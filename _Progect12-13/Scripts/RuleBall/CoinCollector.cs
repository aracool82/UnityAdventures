using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class CoinCollector:MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.TryGetComponent(out Coin coin))
            {
                _ball.AddCoin(coin.Value);
                Destroy(coin.gameObject);
            }
        }
    }
}
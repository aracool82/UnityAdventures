using UnityEngine;

namespace _Progect12_13.Scripts.RuleBall
{
    public class GameRule : MonoBehaviour
    {
        [SerializeField] private Timer timer;
        [SerializeField] private Coin[] _coins;
        [SerializeField] private Ball _ball;

        private bool _isRunning;
        
        private int _allCoins => _coins.Length;

        private void Start()
        {
            if (_coins.Length == 0)
            {
                StopGame();
                Debug.LogError("No coins found!");
            }
            else
            {
                timer.StartCounting();
                _isRunning = true;
            }
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            if (timer.IsOverTime )
                    LoseGame();
            else
                if (IsCollectedAllCoins())
                    WinGame();
        }

        private bool IsCollectedAllCoins()
            => _ball.Coins == _allCoins;

        private void WinGame()
        {
            Debug.Log("Victory");
            StopGame();
        }

        private void LoseGame()
        {
            Debug.Log("Lose game");
            StopGame();
        }

        private void StopGame()
        {
            timer.StopTimer();
            _ball.gameObject.SetActive(false);
            _isRunning = false;
        }
    }
}
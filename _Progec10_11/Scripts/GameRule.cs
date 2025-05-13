using UnityEngine;

namespace Progec10_11
{
    public class GameRule : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        [SerializeField] private Npc _npc;

        [SerializeField] private float _maxDistance;
        [SerializeField] private float _winTime;
        [SerializeField] private float _loseTime;

        private string _loseMessage = "You lose the game!";
        private string _winMessage = "You win the game!";

        private float _winTimeCounter;
        private float _loseTimeCounter;

        private float _distance;
        private float _timerCounter;
        private float _oneSecond = 1f;
        private bool _isRuning = true;

        private void Update()
        {
            if (_isRuning == false)
                return;

            _timerCounter += Time.deltaTime;
            _distance = (_hero.transform.position - _npc.transform.position).magnitude;

            if (IsTickSecond())
                CalculateTime();

            if (IsLoseHero())
                StopGame(_loseMessage);

            if (IsWinHero())
                StopGame(_winMessage);
        }

        public void RestartGame()
        {
            ResetCounters();

            _hero.transform.position = Vector3.forward;
            _npc.transform.position = Vector3.zero;

            _hero.StartMovement();
            _npc.StartMovement();
            _isRuning = true;
        }

        private void StopGame(string message)
        {
            _hero.Stop();
            _npc.Stop();
            _isRuning = false;

            Debug.Log(message);
        }

        private void ResetCounters()
        {
            _winTimeCounter = 0;
            _loseTimeCounter = 0;
            _timerCounter = 0;
        }

        private void CalculateTime()
        {
            if (_distance > _maxDistance)
                _loseTimeCounter++;
            else
                _winTimeCounter++;
        }

        private bool IsTickSecond()
        {
            if (_timerCounter >= _oneSecond)
            {
                _timerCounter = 0;
                return true;
            }

            return false;
        }

        private bool IsLoseHero()
            => _loseTimeCounter >= _loseTime;

        private bool IsWinHero()
            => _winTimeCounter >= _winTime;
    }
}
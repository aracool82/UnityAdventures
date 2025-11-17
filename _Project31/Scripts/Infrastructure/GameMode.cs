using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class GameMode
    {
        public event Action Win;
        public event Action Defeat;

        private Timer _timer;
        private Hero _hero;
        private EnemySpawner _spawner;
        private TypeWin _typeWin;
        private TypeDefeat _typeDefeat;
        private float _timeToWin = 15;
        private int _kiledEnemyCount = 5;
        private int _killedEnemyCounter = 0;
        private int _spawnedEnemyCounter;

        public GameMode(Hero hero, EnemySpawner spawner, TypeWin typeWin, TypeDefeat typeDefeat)
        {
            _timer = new Timer(_timeToWin);
            _hero = hero;
            _spawner = spawner;
            _typeWin = typeWin;
            _typeDefeat = typeDefeat;
            Subscribe();
        }

        public void Subscribe()
        {
            if (_typeWin == TypeWin.TimeToWin)
                _timer.IsFinished.Changed += OnTimerEnded;

            if (_typeWin == TypeWin.KilledEnemys)
            {
                _spawner.KilledEnemy += OnKilledEnemy;
            }

            if (_typeDefeat == TypeDefeat.HeroDead)
                _hero.Dead += OnHeroDead;

            if (_typeDefeat == TypeDefeat.SpawedEnemys)
            {
                //инфа от спавнера 
            }
        }

        private void OnKilledEnemy()
        {
            _killedEnemyCounter++;
            
            if(_killedEnemyCounter == _kiledEnemyCount)
                Win?.Invoke();
        }

        private void OnHeroDead()
        {
            Debug.Log("Hero Dead. Game Defeat");
            _hero.Dead -= OnHeroDead;
            Defeat?.Invoke();
        }

        private void OnTimerEnded(bool arg1, bool arg2)
        {
            if (_hero.IsDead == false)
            {
                Debug.Log("Time is over. Game win");
                _timer.IsFinished.Changed -= OnTimerEnded;
                Win?.Invoke();
            }
        }
    }
}
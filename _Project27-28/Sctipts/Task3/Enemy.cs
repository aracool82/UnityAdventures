using System;
using UnityEngine;

namespace _Project27_28.Scripts.Task3
{
    public class Enemy : IUpdateble
    {   
        private Func<bool> _conditionDead;
        public event  Action<Enemy> Deaed;
        
        private float _lifeTime ;
        private float _currentTime = 0;

        public Enemy(float lifeTime)
            => _lifeTime = lifeTime;


        public float LifeTime => _lifeTime;
        public float CurrentTime => _currentTime;
        public bool IsDead => _currentTime >= _lifeTime;


        public void UpdateLogic(float deltaTime)
        {
            if (IsDead)
                return;

            _currentTime += deltaTime;
            
            if(_conditionDead != null)
                if (_conditionDead.Invoke())
                    Deaed?.Invoke(this);
        }

        public void SetConditionDead(Func<bool> condition)
            =>_conditionDead = condition;

        private bool IsDeadEnemy()
        {
            return true;
        }
    }
}
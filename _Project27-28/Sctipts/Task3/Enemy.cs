using System;

namespace _Project27_28.Scripts.Task3
{
    public class Enemy : IUpdateble
    {   
        private Func<bool> ConditionDead;
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
            _currentTime += deltaTime;
            
            if(ConditionDead != null)
                if (ConditionDead.Invoke())
                    Deaed?.Invoke(this);
        }

        public void SetConditionDead(Func<bool> condition)
            =>ConditionDead = condition;
    }
}
using System;
using UnityEngine;

namespace _Project31.Scripts
{
    public class ConditionsFabric
    {
        public ICondition CreateHeroDeadCondition(Hero hero)
            => new HeroDead(
                () => hero.IsDead,
                "Hero is dead");

        public ICondition CreateTimeIsOverCondition(Timer timer, Hero hero)
            => new TimerIsOver(
                () => Mathf.Abs(timer.MaxTime.Value - timer.CurrentTime.Value) < 0.01 && hero.IsDead == false,
                "Timer is over");
    }

    public interface ICondition
    {
        bool IsCompleted { get; }
        string Description { get; }
    }

    public class TimerIsOver : ICondition
    {
        private readonly Func<bool> _condition;

        public TimerIsOver(Func<bool> condition, string description)
        {
            _condition = condition;
            Description = description;
        }

        public string Description { get; }

        public bool IsCompleted
            => _condition.Invoke();
    }

    public class HeroDead : ICondition
    {
        private readonly Func<bool> _condition;

        public HeroDead(Func<bool> condition, string description)
        {
            _condition = condition;
            Description = description;
        }

        public string Description { get; }

        public bool IsCompleted
            => _condition.Invoke();
    }
}
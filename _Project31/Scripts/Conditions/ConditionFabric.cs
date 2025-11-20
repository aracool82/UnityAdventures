using System;

namespace _Project31.Scripts
{
    public class ConditionsFabric
    {
        public Condition Create(Func<bool> condition,string description)
            => new Condition(condition, description);

    }

    public class Condition 
    {
        private readonly Func<bool> _condition;

        public Condition(Func<bool> condition, string description)
        {
            _condition = condition;
            Description = description;
        }

        public string Description { get; }

        public bool IsCompleted
            => _condition.Invoke();
    }

}
using System;

namespace _Project29_30.Scripts.ReactiveGeneric_Health
{
    public interface IReadOnlyVariable<T> 
    {
         event Action<T,T> Changed;
        
         T Value { get; }
    }
}
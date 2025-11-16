using System;

namespace _Project31.Scripts
{
    public interface IReadOnlyVariable<T> 
    {
         event Action<T,T> Changed;
        
         T Value { get; }
    }
}
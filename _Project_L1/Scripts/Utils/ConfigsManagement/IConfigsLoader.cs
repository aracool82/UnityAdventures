using System;
using System.Collections;
using System.Collections.Generic;

namespace _Project_L1.Scripts.Utils
{
    public interface IConfigsLoader
    {
        IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded);
    }
}
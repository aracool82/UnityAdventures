using System;

namespace _Project_L1.Scripts.Services
{
    public interface IModeService
    {
         event Action Win;
         event Action Defeat;

         public void Start();
    }
}
using System.Collections.Generic;

namespace _Project27_28.Scripts.Task3
{
    public class Updater 
    {
        private List<IUpdateble> _updatebles = new ();

        public void UpdateLogic(float deltaTime)
        {
            if(_updatebles.Count == 0)
                return;

            foreach ( IUpdateble IUpadateble in _updatebles)
                IUpadateble.UpdateLogic(deltaTime);
        }

        public void AddUpadateble(IUpdateble updateble)
        {
            if(updateble == null)
                return;
            
            _updatebles.Add(updateble);
        }
    }

}
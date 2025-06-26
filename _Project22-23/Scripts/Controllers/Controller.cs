using UnityEngine.AI;

namespace _Project22_23.Scripts
{
    public abstract class Controller
    {
        protected NavMeshPath Path;
        protected NavMeshQueryFilter Filter;
        
        private bool _isEnable;

        protected Controller()
        {
            Path = new NavMeshPath();
            Filter.agentTypeID = 0;
            Filter.areaMask = NavMesh.AllAreas;
        }

        public virtual void Enable() 
            => _isEnable = true;
        
        public virtual void Disable()
            => _isEnable = false;

        public void Update(float deltaTime)
        {
            if(_isEnable == false)
                return;

            UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
    }
}
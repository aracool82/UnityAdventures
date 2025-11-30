using _Project_L1.Scripts;
using _Project_L1.Scripts.Infrastructure;
using _Project_L1.Scripts.Services;
using _Project_L1.Scripts.Utils.CoroutineManagement;

namespace _Project_L1
{
    public class ModeFactory
    {
        public IModeService CreateMode(
            LevelConfig levelConfig,
            SequenceTypes sequenceTypes,
            ICoroutinePerformer coroutinePerformer)
        
            => new GameMode(levelConfig.GetSequence(sequenceTypes), coroutinePerformer);
    }
}
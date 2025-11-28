using _Project_L1.Scripts.Infrastructure;

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
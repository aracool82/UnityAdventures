using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Stats stats;
        [SerializeField] private float _targetDistance;

        private AggressionDetector _aggressionDetector;

        private IBehavior _behaviorRest;
        private IBehavior _behaviorReaction;

        public bool _enabled;

        private Transform _target;

        public void Initialize(Transform target)
        {
            _target = target;
            _aggressionDetector = new AggressionDetector(target, transform);
        }

        private void Update()
        {
            _enabled = _behaviorReaction.IsEnabled;
            _targetDistance = Vector3.Distance(transform.position, _target.position);
            _aggressionDetector.Update(_target, transform);

            stats = _aggressionDetector.IsDecected ? Stats.Reaction : Stats.AtRest;

            if (stats == Stats.AtRest)
            {
                if (_behaviorRest.IsEnabled)
                {
                    _behaviorRest.DoAction();
                    _behaviorRest.Update();
                }
            }
            else if (stats == Stats.Reaction)
            {
                _behaviorReaction.DoAction();
                
                if (_behaviorReaction.IsEnabled)
                    _behaviorReaction.Update();
            }
        }

        // public void SetParticlEffect(ParticleSystem effect)
        // {
        //     if (effect == null)
        //         Debug.Log("Null particle system");
        //
        //     if (_behaviorReaction is ReactionBehaviorDead)
        //     {
        //         _deadEffect = Instantiate(effect, transform);
        //         Debug.Log("Создали" +_deadEffect.name);
        //     }
        // }

        public void SetBehaviorsRest(IBehavior behaviorRest)
        {
            if (IsValidBehavior(behaviorRest))
                _behaviorRest = behaviorRest;
        }

        public void SetBehaviorsReaction(IBehavior behaviorReaction)
        {
            if (IsValidBehavior(behaviorReaction))
                _behaviorReaction = behaviorReaction;
        }

        private bool IsValidBehavior(IBehavior behavior)
        {
            if (behavior == null)
            {
                Debug.LogError("Behavior is null");
                return false;
            }

            return true;
        }
    }
}
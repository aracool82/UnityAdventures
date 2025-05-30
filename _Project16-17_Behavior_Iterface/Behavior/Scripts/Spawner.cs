using System.Collections.Generic;
using UnityEngine;

namespace _Project16_17.Scripts
{
    public class Spawner : MonoBehaviour
    {
        private const float EnemySpeed = 3f;

        [SerializeField] private ParticleSystem _deadEffect;
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private Enemy _enemyPrefab;

        [SerializeField] private Reactions _reaction = Reactions.Dead;
        [SerializeField] private Rests _rest = Rests.NoMove;

        private List<Transform> _points = new();

        private void Awake()
        {
            _points = GetPoints();
            CreateEnemy();
        }

        private void CreateEnemy()
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);

            enemy.SetBehaviorsReaction(GetReactionBehavior(_characterTransform, enemy.gameObject, _deadEffect));
            enemy.SetBehaviorsRest(GetRestBehavior(enemy.transform));
            enemy.Initialize(_characterTransform,new AggressionDetector(_characterTransform,enemy.transform));
        }

        private IBehavior GetRestBehavior(Transform source)
        {
            IBehavior restBehavior = null;

            switch (_rest)
            {
                case Rests.Patroll:
                    restBehavior = new RestBehaviorPatroll(source, _points, EnemySpeed);
                    break;

                case Rests.NoMove:
                    restBehavior = new RestBehaviorStandInPlace();
                    break;

                case Rests.RandomDirectionMove:
                    restBehavior = new RestBehaviorRandomMovement(source,EnemySpeed);
                    break;

                default:
                    Debug.LogError("Unknown selected Rest");
                    break;
            }

            return restBehavior;
        }

        private IBehavior GetReactionBehavior(Transform characterTransform, GameObject source,
            ParticleSystem deadeffect)
        {
            IBehavior reactionBehavior = null;

            switch (_reaction)
            {
                case Reactions.FollowToTarget:
                    reactionBehavior = new ReactionBehaviorFollowTo(source.transform, characterTransform,EnemySpeed);
                    break;

                case Reactions.RunAway:
                    reactionBehavior = new ReactionBehaviorRunAway(source.transform, characterTransform,EnemySpeed);
                    break;

                case Reactions.Dead:
                    reactionBehavior = new ReactionBehaviorDead(source, deadeffect);
                    break;

                default:
                    Debug.LogError("Unknown selected Reaction");
                    break;
            }

            return reactionBehavior;
        }

        private List<Transform> GetPoints()
        {
            List<Transform> points = new();
            int childCount = transform.childCount;
            int minCount = 1;

            if (childCount < minCount)
                Debug.LogError($"Minimum Transform count is {minCount}");

            for (int i = 0; i < childCount; i++)
                points.Add(transform.GetChild(i));

            return points;
        }
    }
}
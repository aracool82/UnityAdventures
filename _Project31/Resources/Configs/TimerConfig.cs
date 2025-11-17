using UnityEngine;

namespace _Project31.Scripts
{
    [CreateAssetMenu(fileName = "TimerConfig", menuName = "Config/TimerConfig")]
    public class TimerConfig : ScriptableObject
    {
        [field: SerializeField] public float TimeInterval { get; set; } = 5;
    }
}